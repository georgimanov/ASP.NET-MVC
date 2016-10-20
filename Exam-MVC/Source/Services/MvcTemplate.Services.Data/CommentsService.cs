namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> categories)
        {
            this.comments = categories;
        }

        public void Create(int id, string comment, string email)
        {
            var commentToAdd = new Comment()
            {
                AuthorEmail = email,
                AuthorIp = "some ip",
                Content = comment,
                IdeaId = id,
            };

            this.comments.Add(commentToAdd);
            this.comments.Save();
        }

        public void Destroy(int id)
        {
            var entity = this.comments.GetById(id);
            this.comments.Delete(entity);
            this.comments.Save();
        }

        public IQueryable<Comment> GetAll(int skip, int take)
        {
            return this.comments.All().OrderBy(x => x.CreatedOn).Skip(skip).Take(take);
        }

        public void Update(int id, string email, string content)
        {
            var entity = this.comments.GetById(id);
            entity.Content = content;
            entity.AuthorEmail = email;

            this.comments.Save();
        }
    }
}
