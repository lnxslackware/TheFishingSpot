using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheFishingSpot.Web.Areas.News.Models
{
    public class CommentInputViewModel
    {
        public int NewsId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}