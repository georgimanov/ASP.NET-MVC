namespace SportSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Data;

    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
    }
}