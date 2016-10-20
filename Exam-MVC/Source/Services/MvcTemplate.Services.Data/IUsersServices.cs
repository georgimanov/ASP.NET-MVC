namespace MvcTemplate.Services.Data
{
    using MvcTemplate.Data.Models;
    using System.Linq;

    public interface IUsersServices
    {
        IQueryable<ApplicationUser> GetUser(string username);
    }
}
