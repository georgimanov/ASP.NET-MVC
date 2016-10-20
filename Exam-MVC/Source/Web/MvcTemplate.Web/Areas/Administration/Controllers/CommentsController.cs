namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data;

    public class CommentsController : Controller
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService commentsService)
        {
            this.comments = commentsService;
        }

        [HttpGet]
        public ActionResult All()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var commentsViewModel = this.comments
                .GetAll(0, 100)
                .To<CommentViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(commentsViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CommentViewModel comment)
        {
            this.comments
                .Update(comment.Id, comment.AuthorEmail, comment.Content);

            var commentsViewModel = this.comments
                .GetAll(0, 100)
                .To<CommentViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(commentsViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CommentViewModel comment)
        {
            this.comments
                .Destroy(comment.Id);

            var commentsViewModel = this.comments
                .GetAll(0, 100)
                .To<CommentViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(commentsViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
