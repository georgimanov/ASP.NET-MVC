namespace MvcTemplate.Web.Areas.Administration.Models
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        [HiddenInput(DisplayValue = false)]
        public string AuthorIpAdress
        {
            get; set;
        }
    }
}
