namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;
    using System;
    using ViewModels.Ideas;
    using System.Collections.Generic;

    public class IdeasController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly IIdeasService ideas;

        public IdeasController(IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Details(string url)
        {
            var allItemsCount = this.ideas.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var idea = this.ideas.GetByUrl(url);
            var ideaViewModel = this.Mapper.Map<IdeaViewModel>(idea);
            var comments = new List<ViewModels.Ideas.CommentViewModel>();
            comments = idea.Comments
                .AsQueryable()
                .To<ViewModels.Ideas.CommentViewModel>()
                .ToList();

            var detailsIdeaViewModel = new IdeaDetailsViewModel()
            {
                Comments = comments,
                Idea = ideaViewModel,
                CurrentPage = 1,
                TotalPages = totalPages
            };

            return this.View(detailsIdeaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string idea, string description)
        {
            if (string.IsNullOrEmpty(idea) || string.IsNullOrEmpty(description))
            {
                return this.View("~/Home");
            }

            var url = this.ideas.Create(idea, description);

            return this.Redirect($"~/suggestions/{url}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var idea = this.ideas.GetBySearch(search);
            var viewModel = this.ideas
               .GetBySearch(search)
               .To<IdeaViewModel>()
               .ToList();

            return this.View(viewModel);
        }
    }
}
