using System.Web.Mvc;

namespace Core.Areas.QueryBuilder
{
    public class QueryBuilderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "QueryBuilder";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "QueryBuilder_default",
                "{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
