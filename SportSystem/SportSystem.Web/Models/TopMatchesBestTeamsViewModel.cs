namespace SportSystem.Web.Models
{
    using System.Collections.Generic;

    public class TopMatchesBestTeamsViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}