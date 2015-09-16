using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportSystem.Common;

namespace SportSystem.Web.Controllers
{
    using Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
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
                .Take(Constants.NumberOfMathecsToListOnFirstPage);

            var teams = this.db.Teams
                .OrderBy(x => x.DateFounded)
                .Select(x => new TeamViewModel
                {
                    TeamId = x.TeamId,
                    TeamName = x.TeamName,
                    WebSite = x.WebSite,
                    Votes = x.Votes.Count
                })
                .Take(Constants.NumberOfTeamsToListOnFirstPage);

            return View(new TopMatchesBestTeamsViewModel()
            {
                Matches = matches,
                Teams = teams
            });
        }
    }
}