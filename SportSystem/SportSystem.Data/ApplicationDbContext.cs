namespace SportSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}