namespace TheFishingSpot.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Fish> catchedFishes;

        public ApplicationUser()
        {
            this.catchedFishes = new HashSet<Fish>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Fish> CatchedFishes
        {
            get
            {
                return this.catchedFishes;
            }

            set
            {
                this.catchedFishes = value;
            }
        }
    }
}