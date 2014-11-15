namespace TheFishingSpot.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FishingPlace
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public FishingPlaceType Type { get; set; }
    }
}