namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data;

    public class IdeasController : Controller
    {
        private readonly IIdeasService ideas;

        public IdeasController(IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var ideasViewModel = this.ideas
                .GetAll()
                .To<IdeaViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(ideasViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, IdeaViewModel model)
        {
            this.ideas
                .Update(model.Id, model.Title, model.Description);

            var ideasViewModel = this.ideas
                .GetAll()
                .To<IdeaViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(ideasViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, IdeaViewModel model)
        {
            this.ideas
                .Destroy(model.Id);

            var ideasViewModel = this.ideas
                .GetAll()
                .To<IdeaViewModel>()
                .ToList()
                .ToDataSourceResult(request);

            return this.Json(ideasViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
