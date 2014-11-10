namespace TheFishingSpot.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheFishingSpot.Models;

    public interface IFishingSpotDbContext
    {
        IDbSet<Fish> Fishes { get; set; }
        IDbSet<News> News { get; set; }
        IDbSet<Comment> Comments { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
