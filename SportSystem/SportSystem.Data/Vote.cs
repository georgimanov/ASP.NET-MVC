namespace SportSystem.Data
{
    public class Vote
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int Value { get; set; }
    }
}
