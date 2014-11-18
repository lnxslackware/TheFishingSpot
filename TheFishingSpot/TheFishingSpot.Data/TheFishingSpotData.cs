namespace TheFishingSpot.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using TheFishingSpot.Data.Repositories;
    using TheFishingSpot.Models;

    public class TheFishingSpotData : IFishingSpotData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public TheFishingSpotData()
            : this(new TheFishingSpotDbContext())
        {
        }

        public TheFishingSpotData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public Repositories.IRepository<Fish> Fishes
        {
            get
            {
                return this.GetRepository<Fish>();
            }
        }

        public Repositories.IRepository<News> News
        {
            get
            {
                return this.GetRepository<News>();
            }
        }

        public Repositories.IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }


        public IRepository<FishingPlace> FishingPlaces
        {
            get
            {
                return this.GetRepository<FishingPlace>();
            }
        }


        public IRepository<ApplicationUser> Users
        {
            get 
            {
                return this.GetRepository<ApplicationUser>();
            }
        }
    }
}