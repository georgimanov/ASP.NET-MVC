namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IIdeasService
    {
        IQueryable<Idea> GetAll();

        IQueryable<Idea> GetAll(int skip, int take);

        IQueryable<Idea> GetAllByDate(int skip, int take);

        IQueryable<Idea> GetIdeasByVotes(int count);

        IQueryable<Idea> GetIdeasByDate(int count);

        IQueryable<Idea> GetBySearch(string url);

        Idea GetByUrl(string url);

        string Create(string idea, string description);

        void Update(int id, string title, string description);

        void Destroy(int id);
    }
}
