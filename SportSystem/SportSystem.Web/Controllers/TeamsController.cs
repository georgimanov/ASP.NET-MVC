namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using InputModel;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class TeamsController : BaseController
    {
        // GET: Teams
        [AllowAnonymous]
        public ActionResult Index()
        {
            this.RedirectToAction("Index", "Home");
            return null;
        }

        public ActionResult Details(int id)
        {
            var team = this.db.Teams
                .Select(x => new TeamDetailsViewModel
                {
                    Id = x.TeamId,
                    Name = x.TeamName,
                    Nickname = x.Nickname,
                    Votes = x.Votes.Count,
                    DateFounded = x.DateFounded,
                    Players = x.Players.ToList()
                })
                .FirstOrDefault(x => x.Id == id);

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int? teamId)
        {
            var team = this.db.Teams
                .FirstOrDefault(x => x.TeamId == teamId);

            if (team != null)
            {
                var userHasVoted = team.Votes.Any(x => x.AuthorId == this.User.Identity.GetUserId());
                if (!userHasVoted)
                {
                    this.db.Votes.Add(new Vote
                    {
                        TeamId = team.TeamId,
                        AuthorId = this.User.Identity.GetUserId(),
                        Value = 1
                    });
                    this.db.SaveChanges();
                }

                var votesCount = team.Votes.Sum(x => x.Value);
                return this.RedirectToAction("Details", new { Id = team.TeamId });
                //return this.Content(votesCount.ToString());
            }

            return new EmptyResult();
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamImputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = new Team()
                {
                    TeamName = model.TeamName,
                    Nickname = model.Nickname,
                    DateFounded = model.DateFounded,
                    WebSite = model.WebSite,
                };
                this.db.Teams.Add(team);
                this.db.SaveChanges();

                return this.RedirectToAction("Details", new { Id = team.TeamId});
            }

            return View(model);
        }
    }
}