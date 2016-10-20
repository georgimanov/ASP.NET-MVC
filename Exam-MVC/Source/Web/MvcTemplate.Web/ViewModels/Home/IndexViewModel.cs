namespace MvcTemplate.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IdeaViewModel> Ideas { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
