namespace SportSystem.Web.Models
{
    using System;
    using System.Collections.Generic;

    using Data;

    public class TeamDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public int Votes { get; set; }

        public DateTime DateFounded { get; set; }

        public bool UserHasVoted { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}