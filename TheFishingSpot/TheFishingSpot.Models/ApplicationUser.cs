namespace TheFishingSpot.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

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