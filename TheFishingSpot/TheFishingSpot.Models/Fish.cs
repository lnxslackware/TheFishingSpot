namespace TheFishingSpot.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Fish
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public FishType Type { get; set; }
        public double MinimalAllowedSize { get; set; }
        public string AdditionalInfo { get; set; }
    }
}