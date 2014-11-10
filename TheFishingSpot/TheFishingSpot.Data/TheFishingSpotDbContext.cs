namespace TheFishingSpot.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheFishingSpot.Data.Migrations;
    using TheFishingSpot.Models;

    public class TheFishingSpotDbContext : IdentityDbContext<ApplicationUser>, IFishingSpotDbContext
    {
        public TheFishingSpotDbContext()
            : base("name=FishingSpotConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TheFishingSpotDbContext, Configuration>());
        }

        public static TheFishingSpotDbContext Create()
        {
            return new TheFishingSpotDbContext();
        }

        public IDbSet<Fish> Fishes { get; set; }
        public IDbSet<News> News { get; set; }
        public IDbSet<Comment> Comments { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}