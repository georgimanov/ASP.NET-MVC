namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Data;

    public class UsersService : IUsersServices
    {
        private ApplicationDbContext dbContext;

        public UsersService()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public IQueryable<ApplicationUser> GetUser(string username)
        {
            return this.dbContext.Users;
        }
    }
}
