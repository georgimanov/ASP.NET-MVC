namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Services.Data;

    public class CommentsController : Controller
    {
        private ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id, string comment, string email)
        {
            if (string.IsNullOrEmpty(comment) || string.IsNullOrEmpty(email))
            {
                return this.View("/");
            }

            this.comments.Create(id, comment, email);

            this.TempData["Notification"] = "Thank you for your comment!";

            return this.Redirect("/");
        }
    }
}