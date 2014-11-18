namespace TheFishingSpot.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper;


    using TheFishingSpot.Data;
    using TheFishingSpot.Models;
    using TheFishingSpot.Web.Models;

    using Microsoft.AspNet.Identity;

    public class UserController : BaseController
    {
        public UserController(IFishingSpotData data)
            : base(data)
        {
        }

        public ActionResult Profile(string id)
        {
            var user = this.Data.Users.GetById(id);

            if (id == null)
            {
                user = this.Data.Users.GetById(this.User.Identity.GetUserId());
            }

            var viewModel = Mapper.Map<ApplicationUser, UserProfileViewModel>(user);

            return View(viewModel);
        }
    }
}