namespace TheFishingSpot.Data
{
    using System.Data.Entity;

    using TheFishingSpot.Data.Repositories;
    using TheFishingSpot.Models;

    public interface IFishingSpotData
    {
        DbContext Context { get; }
        IRepository<Fish> Fishes { get; }

        IRepository<News> News { get; }

        IRepository<Comment> Comments { get; }

        IRepository<FishingPlace> FishingPlaces { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
