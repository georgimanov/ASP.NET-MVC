namespace MvcTemplate.Web.Controllers.Tests
{
    using Moq;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Home;

    using NUnit.Framework;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class IdeasControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(IdeasController).Assembly);
            const string IdeaContent = "SomeContent";
            var ideasServiceMock = new Mock<IIdeasService>();
            ideasServiceMock.Setup(x => x.GetByUrl(It.IsAny<string>()))
                .Returns(new Idea
                {
                    Description = IdeaContent
                    /*Category = new JokeCategory { Name = "asda" } */
                });
            var controller = new IdeasController(ideasServiceMock.Object);
            controller.WithCallTo(x => x.Details("asdasasd"))
                .ShouldRenderView("Suggestions")
                .WithModel<IdeaViewModel>(
                    viewModel =>
                        {
                            Assert.AreEqual(IdeaContent, viewModel.Description);
                        }).AndNoModelErrors();
        }
    }
}
