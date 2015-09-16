namespace SportSystem.Web.Models
{
    using System;

    public class MatchViewModel
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public int AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime MatchDate { get; set; }
    }
}