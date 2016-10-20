namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll(int skip, int take);

        void Create(int id, string comment, string email);

        void Update(int id, string email, string content);

        void Destroy(int id);
    }
}
