namespace TheFishingSpot.Web.Controllers
{
    using System.Web.Mvc;

    using TheFishingSpot.Data;

    public abstract class BaseController : Controller
    {
        private IFishingSpotData data;

        public BaseController(IFishingSpotData data)
        {
            this.data = data;
        }

        protected IFishingSpotData Data 
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }
    }
}