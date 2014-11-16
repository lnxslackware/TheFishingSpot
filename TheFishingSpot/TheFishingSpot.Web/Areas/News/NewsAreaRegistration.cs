using System.Web.Mvc;

namespace TheFishingSpot.Web.Areas.News
{
    public class NewsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "News";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Comments",
                "News/Comments/{action}/{id}",
                new { controller = "Comments", action = "Index", id = UrlParameter.Optional }
                );

            context.MapRoute(
                "News_default",
                "News/{action}/{id}",
                new { controller = "News", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}