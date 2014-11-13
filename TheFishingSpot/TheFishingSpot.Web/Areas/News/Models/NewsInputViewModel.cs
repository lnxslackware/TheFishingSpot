using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheFishingSpot.Web.Areas.News.Models
{
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