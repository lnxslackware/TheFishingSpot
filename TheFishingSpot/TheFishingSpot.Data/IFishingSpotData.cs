namespace TheFishingSpot.Data
{
    using TheFishingSpot.Data.Repositories;
    using TheFishingSpot.Models;

    public interface IFishingSpotData
    {

        IRepository<Fish> Fishes { get; }

        IRepository<News> News { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
