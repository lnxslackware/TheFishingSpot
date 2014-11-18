namespace TheFishingSpot.Web.Models
{
    using System.Linq;

    using AutoMapper;
    
    using TheFishingSpot.Models;
    using TheFishingSpot.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Username { get; set; }
        
        [Display(Name="Catched fishes")]
        public int CatchedFishesCount { get; set; }

        [Display(Name="Biggest fish")]
        public Fish BiggestFish { get; set; }

        [Display(Name="Catched fishes")]
        public IEnumerable<Fish> CatchedFishes { get; set; }

        public FishIputViewModel FishInputModel { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserProfileViewModel>()
                .ForMember(vm => vm.CatchedFishesCount, opt => opt.MapFrom(u => u.CatchedFishes.Count()))
                .ForMember(vm => vm.BiggestFish, opt => opt.MapFrom(u => u.CatchedFishes
                    .OrderByDescending(f => f.Weight).FirstOrDefault()));
        }
    }
}