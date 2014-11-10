using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheFishingSpot.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
