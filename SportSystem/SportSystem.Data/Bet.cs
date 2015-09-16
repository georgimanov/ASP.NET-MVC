namespace SportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}
