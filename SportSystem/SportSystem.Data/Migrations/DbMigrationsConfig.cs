namespace SportSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class DbMigrationsConfig
        : DbMigrationsConfiguration<SportSystem.Data.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SportSystem.Data.ApplicationDbContext context)
        {
            if (!context.Users.Any() || !context.Teams.Any())
            {
                // TEAMS
                var manU = new Team()
                {
                    TeamName = "Manchester United F.C.",
                    WebSite = "http://www.manutd.com",
                    DateFounded = new DateTime(1878, 6, 1),
                    Nickname = "The Red Devils"
                };

                context.Teams.Add(manU);

                var rm = new Team()
                {
                    TeamName = "Real Madrid",
                    WebSite = "http://www.realmadrid.com",
                    DateFounded = new DateTime(1902, 3, 6),
                    Nickname = "The Whites"
                };

                context.Teams.Add(rm);

                var barca = new Team()
                {
                    TeamName = "FC Barcelona",
                    WebSite = "http://www.fcbarcelona.com",
                    DateFounded = new DateTime(1899, 11, 12),
                    Nickname = "Barca"
                };

                context.Teams.Add(barca);

                var bm = new Team()
                {
                    TeamName = "Bayern Munich",
                    WebSite = "http://www.fcbayern.de",
                    DateFounded = new DateTime(1900, 2, 13),
                    Nickname = "The Bavarians"
                };

                context.Teams.Add(bm);

                var mc = new Team()
                {
                    TeamName = "Manchester City",
                    WebSite = "http://www.mcfc.com",
                    DateFounded = new DateTime(1880, 5, 1),
                    Nickname = "The Citizens"
                };

                context.Teams.Add(mc);

                var chelsea = new Team()
                {
                    TeamName = "Chelsea",
                    WebSite = "https://www.chelseafc.com",
                    DateFounded = new DateTime(1905, 3, 10),
                    Nickname = "The Pensioners"
                };

                context.Teams.Add(chelsea);
                context.SaveChanges();

                // MATCHES
                var match1 = new Match()
                {
                    HomeTeam = rm,
                    AwayTeam = manU,
                    MatchDate = new DateTime(2015, 6, 13)
                };

                context.Matches.Add(match1);

                var match2 = new Match()
                {
                    HomeTeam= bm,
                    AwayTeam= manU,
                    MatchDate = new DateTime(2015, 6, 14)
                };

                context.Matches.Add(match2);

                var match3 = new Match()
                {
                    HomeTeam = barca,
                    AwayTeam = mc,
                    MatchDate = new DateTime(2015, 6, 15)
                };

                context.Matches.Add(match3);

                var match4 = new Match()
                {
                    HomeTeam = chelsea,
                    AwayTeam = barca,
                    MatchDate = new DateTime(2015, 6, 16)
                };

                context.Matches.Add(match4);

                var match5 = new Match()
                {
                    HomeTeam = rm,
                    AwayTeam = mc,
                    MatchDate = new DateTime(2015, 6, 17)
                };

                context.Matches.Add(match5);

                var match6 = new Match()
                {
                    HomeTeam = manU,
                    AwayTeam = chelsea,
                    MatchDate = new DateTime(2015, 6, 18)
                };

                context.Matches.Add(match6);
                context.SaveChanges();

                var alexis = new Player()
                {
                    Name = "Alexis Sanchez",
                    BirthDate = new DateTime(1982, 1, 3),
                    Height = 1.65m,
                    TeamId = barca.TeamId
                };
                context.Players.Add(alexis);

                var messi = new Player()
                {
                    Name = "Lionel Messi",
                    BirthDate = new DateTime(1982, 1, 13),
                    Height = 1.65m
                };

                context.Players.Add(messi);

                context.SaveChanges();

                // USER 
                //var pass = new PasswordHasher();
                //pass.HashPassword("123");

                //var someUser = new ApplicationUser
                //{
                //    UserName = "test",
                //    Email = "test@test.bg",
                //    PasswordHash = pass.ToString()
                //};

                
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "dj@dj.com", PhoneNumber = "0797697898" };
                userManager.Create(userToInsert, "Password@123");
                

                var comment1 = new Comment()
                {
                    Author = userToInsert,
                    Content = "The best match this summer!"
                };

                match1.Comments.Add(comment1);

                var comment2 = new Comment()
                {
                    Author = userToInsert,
                    Content = "The good football this evening."
                };

                match1.Comments.Add(comment2);

                var comment3 = new Comment()
                {
                    Author = userToInsert,
                    Content = "Bayern!"
                };

                match2.Comments.Add(comment3);

                context.SaveChanges();

            }
        }
    }
}
