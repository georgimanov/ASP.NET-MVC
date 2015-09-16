namespace SportSystem.Web.Models
{
    using Data;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }
    }
}