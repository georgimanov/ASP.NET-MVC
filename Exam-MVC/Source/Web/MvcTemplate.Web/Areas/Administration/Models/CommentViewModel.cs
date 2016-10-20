namespace MvcTemplate.Web.Areas.Administration.Models
{
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get; set;
        }

        public string Content
        {
            get; set;
        }

        public string AuthorEmail
        {
            get; set;
        }

        [HiddenInput(DisplayValue = false)]
        public string AuthorIp
        {
            get; set;
        }

        [HiddenInput(DisplayValue = false)]
        public string CreatedOn
        {
            get; set;
        }
    }
}
