namespace TheFishingSpot.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
