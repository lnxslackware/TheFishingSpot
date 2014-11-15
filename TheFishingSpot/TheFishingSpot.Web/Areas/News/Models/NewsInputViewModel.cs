namespace TheFishingSpot.Web.Areas.News.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class NewsInputViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        [AllowHtml]
        public string Content { get; set; }
    }
}