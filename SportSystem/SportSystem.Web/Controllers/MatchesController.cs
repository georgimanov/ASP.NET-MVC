namespace SportSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using InputModel;
    using Microsoft.AspNet.Identity;
    using Models;
    using PagedList;

    [Authorize]
    public class MatchesController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var matches = this.db.Matches
                .OrderBy(x => x.MatchDate)
                .Select(x => new MatchViewModel
                {
                    Id = x.Id,
                    AwayTeamName = x.AwayTeam.TeamName,
                    HomeTeamName = x.HomeTeam.TeamName,
                    MatchDate = x.MatchDate
                })
                .ToPagedList(page ?? Common.Constants.DefaultStartPage, Common.Constants.DefaultPageSize)
                ;

            return View(matches);
        }

        public ActionResult Details(int id)
        {
            var match = this.db.Matches
                .Where(x=> x.Id == id)
                .Select( x=> new MatchDetailsViewModel
                {
                    AwayTeamId = x.AwayTeam.TeamId,
                    AwayTeamName = x.AwayTeam.TeamName,
                    HomeTeamName = x.HomeTeam.TeamName,
                    HomeTeamId = x.HomeTeam.TeamId,
                    MatchDate = x.MatchDate,
                    Comments = x.Comments
                })
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();

            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.UserId = this.User.Identity.GetUserId();
                // some hack
                model.MatchId = 1; 

                var comment = new Comment()
                {
                    Content = model.Content,
                    AuthorId = model.UserId,
                    MatchId = model.MatchId
                };

                this.db.Comments.Add(comment);
                this.db.SaveChanges();

                var commentDb = this.db.Comments
                    .Where(x => x.Id == comment.Id)
                    .Select( x => new CommentViewModel
                    {
                        Content = x.Content,
                        Id = x.Id,
                    });

                // hack on
                RedirectToAction("Details", new {id = 1});
            }

            return this.Json("Error");
        }

    }
}