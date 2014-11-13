using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheFishingSpot.Data;

namespace TheFishingSpot.Web.Controllers
{
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