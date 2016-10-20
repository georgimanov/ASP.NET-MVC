namespace MvcTemplate.Web.ViewModels.Ideas
{
    using System.Collections.Generic;
    using Home;

    public class IdeaDetailsViewModel
    {
        public IdeaViewModel Idea { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
