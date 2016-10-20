namespace MvcTemplate.Web.Areas.Administration
{
    using System.Web.Mvc;

    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Administration_default",
                url: "Administration/{controller}/{action}/{id}",
                defaults: new { controller = "Ideas", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcTemplate.Web.Areas.Administration.Controllers" });
        }
    }
}
