namespace MvcTemplate.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "IdeaPage",
                namespaces: new string[] { "MvcTemplate.Web.Controllers" },
                url: "suggestions/{url}",
                defaults: new { controller = "Ideas", action = "Details" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                namespaces: new string[] { "MvcTemplate.Web.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
