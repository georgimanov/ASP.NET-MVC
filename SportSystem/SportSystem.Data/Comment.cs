namespace SportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}
