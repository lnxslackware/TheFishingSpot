using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheFishingSpot.Web.Areas.News.Models
{
    using System.Linq.Expressions;
    using TheFishingSpot.Models;

    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return c => new CommentViewModel
                {
                    Content = c.Content,
                    AuthorName = c.Author.UserName,
                    CommentDate = c.CommentDate
                };
            }
        }

        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime CommentDate { get; set; }
    }
}