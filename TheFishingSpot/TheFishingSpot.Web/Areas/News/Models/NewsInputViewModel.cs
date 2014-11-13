using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheFishingSpot.Web.Areas.News.Models
{
    public class NewsInputViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}