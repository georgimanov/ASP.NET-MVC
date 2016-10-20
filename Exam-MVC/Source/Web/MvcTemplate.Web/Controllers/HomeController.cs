namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly IIdeasService ideas;

        public HomeController(IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            int page = id;
            var allItemsCount = this.ideas.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var ideas = this.ideas
                .GetAll(itemsToSkip, ItemsPerPage)
                .To<IdeaViewModel>()
                .ToList();

            var viewModel = new IndexViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Ideas = ideas
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult ByDate(int id = 1)
        {
            int page = id;
            var allItemsCount = this.ideas.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var ideas = this.ideas
                .GetAllByDate(itemsToSkip, ItemsPerPage)
                .To<IdeaViewModel>()
                .ToList();

            var viewModel = new IndexViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Ideas = ideas
            };

            return this.View(viewModel);
        }
    }
}
