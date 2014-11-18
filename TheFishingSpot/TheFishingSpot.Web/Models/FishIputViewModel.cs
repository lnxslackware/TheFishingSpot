namespace TheFishingSpot.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using TheFishingSpot.Models;
    using TheFishingSpot.Web.Infrastructure.Mapping;

    public class FishIputViewModel : IMapFrom<Fish>
    {
        [Display(Name = "Fish Name")]
        public string Name { get; set; }

        [Display(Name = "Fish Type")]
        public FishType Type { get; set; }

        [Display(Name = "Kg")]
        public double Weight { get; set; }

        [Display(Name = "Info")]
        [UIHint("TextArea")]
        public string AdditionalInfo { get; set; }
    }
}