namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;

    public class IdeasService : IIdeasService
    {
        private readonly IDbRepository<Idea> ideas;
        private readonly IIdentifierProvider identifierProvider;

        public IdeasService(IDbRepository<Idea> ideas, IIdentifierProvider identifierProvider)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
        }

        public Idea GetByUrl(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var idea = this.ideas.GetById(intId);

            return idea;
        }

        public IQueryable<Idea> GetIdeasByVotes(int count)
        {
            return this.ideas.All().OrderByDescending(x => x.Votes.Count).Take(count);
        }

        public IQueryable<Idea> GetIdeasByDate(int count)
        {
            return this.ideas.All().OrderByDescending(x => x.CreatedOn).Take(count);
        }

        public string Create(string idea, string description)
        {
            var ideaToAdd = new Idea()
            {
                AuthorIpAdress = "TODO",
                Title = idea,
                Description = description,
            };

            this.ideas.Add(ideaToAdd);
            this.ideas.Save();

            var id = this.ideas.All().FirstOrDefault(x => x.Title == idea).Id;

            return this.identifierProvider.EncodeId(id, idea);
        }

        public IQueryable<Idea> GetAll()
        {
            return this.ideas.All();
        }

        public IQueryable<Idea> GetAll(int skip, int take)
        {
            return this.ideas
                .All()
                .OrderByDescending(x => x.Votes.Count)
                .ThenBy(x => x.Id)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Idea> GetAllByDate(int skip, int take)
        {
            return this.ideas
                .All()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(skip)
                .Take(take);
        }

        public void Update(int id, string title, string content)
        {
            var entity = this.ideas.GetById(id);
            entity.Description = content;
            entity.Title = title;

            this.ideas.Save();
        }

        public void Destroy(int id)
        {
            var entity = this.ideas.GetById(id);
            this.ideas.Delete(entity);

            this.ideas.Save();
        }

        public IQueryable<Idea> GetBySearch(string url)
        {
            return this.ideas
                .All()
                .Where(x => x.Title.Contains(url) || x.Description.Contains(url))
                .OrderByDescending(x => x.Votes.Count)
                .ThenBy(x => x.Id);
        }
    }
}
