namespace TheFishingSpot.Web.Areas.News.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputViewModel
    {
        [Required]
        public int NewsId { get; set; }

        [Required]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}