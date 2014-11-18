namespace TheFishingSpot.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using TheFishingSpot.Data;
    using TheFishingSpot.Web.Infrastructure.Caching;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IFishingSpotData data;
        private ICacheService cache;

        public DropDownListPopulator(IFishingSpotData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetFishingPlaces()
        {
            var fishingPlaces = this.cache.Get<IEnumerable<SelectListItem>>("fishingPlaces",
                () =>
                {
                    return this.data.FishingPlaces
                       .All()
                       .Select(fp => new SelectListItem
                       {
                           Value = fp.Id.ToString(),
                           Text = fp.Name
                       })
                       .ToList();
                });

            return fishingPlaces;
        }
    }
}