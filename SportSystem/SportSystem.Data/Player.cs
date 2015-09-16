namespace SportSystem.Data
{
    using System;

    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public decimal Height { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
