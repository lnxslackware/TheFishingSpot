namespace TheFishingSpot.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FishingPlace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public FishingPlaceType Type { get; set; }
    }
}