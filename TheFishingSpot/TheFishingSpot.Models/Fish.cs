namespace TheFishingSpot.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FishType Type { get; set; }
        public double MinimalAllowedSize { get; set; }
        public string AdditionalInfo { get; set; }
    }
}