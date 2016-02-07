namespace Informational.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;


    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var books = new List<string>();
            books.Add("Perer pan");
            books.Add("Winey the pooh");
            books.Add("Code complete");

            this.ViewBag.Books = books;

            return View();
        }
    }
}
