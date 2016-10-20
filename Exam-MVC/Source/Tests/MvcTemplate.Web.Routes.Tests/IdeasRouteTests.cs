namespace MvcTemplate.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class IdeasRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            const string Url = "/suggestions/1-XNA-5";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<IdeasController>(c => c.Details("/suggestions/1-XNA-5"));
        }
    }
}
