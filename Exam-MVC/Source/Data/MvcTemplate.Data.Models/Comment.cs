namespace MvcTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorEmail { get; set; }

        public string AuthorIp { get; set; }

        public int IdeaId
        {
            get;
            set;
        }

        public virtual Idea Idea
        {
            get; set;
        }
    }
}
