namespace TheFishingSpot.Web.Areas.Administration.Controllers
{
    using TheFishingSpot.Data;
    using TheFishingSpot.Web.Controllers;

    public abstract class AdminController : BaseController
    {
        public AdminController(IFishingSpotData data)
            : base(data)
        {

        }
    }
}