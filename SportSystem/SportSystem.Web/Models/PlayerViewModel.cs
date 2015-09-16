namespace SportSystem.Web.Models
{
    using System;

    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Height { get; set; }
    }
}