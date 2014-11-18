namespace TheFishingSpot.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    using TheFishingSpot.Models;

    public interface IFishingSpotDbContext
    {
        IDbSet<Fish> Fishes { get; set; }
        
        IDbSet<News> News { get; set; }
        
        IDbSet<Comment> Comments { get; set; }

        IDbSet<FishingPlace> FishingPlaces { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
