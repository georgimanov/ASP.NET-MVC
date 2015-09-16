namespace SportSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        public Match()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

        public DateTime MatchDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
