namespace SportSystem.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string WebSite { get; set; }

        public DateTime DateFounded { get; set; }

        public string Nickname { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
