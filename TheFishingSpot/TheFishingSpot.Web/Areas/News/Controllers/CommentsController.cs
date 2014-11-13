using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper.QueryableExtensions;
using TheFishingSpot.Data;
using TheFishingSpot.Models;
using TheFishingSpot.Web.Areas.News.Models;
using TheFishingSpot.Web.Controllers;

namespace TheFishingSpot.Web.Areas.News.Controllers
{
    public class CommentsController : BaseController
    {
        public CommentsController(IFishingSpotData data)
            :base(data)
        {
        }

        [HttpGet]
        public ActionResult ShowComments(int id)
        {
            var news = this.Data.News.All()
                .Where(n => n.Id == id);
            if (news == null)
            {
                ViewBag.Error = "Unallowed call";
                return RedirectToAction("Index");   
            }

            var comments = news.Select(n => n.Comments)
                .FirstOrDefault().AsQueryable()
                .Project().To<CommentViewModel>()
                .OrderByDescending(c => c.CommentDate)
                .ToList();
            //var comments = this.Data.News.All()
            //    .FirstOrDefault(n => n.Id == id)
            //    .Comments.AsQueryable()
            //    .OrderByDescending(c => c.CommentDate)
            //    .Select(CommentViewModel.FromComment)
            //    .ToList();

            //return this.Content("test");
            return PartialView("_ShowComments", comments);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowAddCommentForm(int id)
        {
            var commentModel = new CommentInputViewModel
            {
                NewsId = id
            };

            return PartialView("_AddComment", commentModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputViewModel comment)
        {
            var newComment = new Comment
            {
                Content = comment.Content,
                CommentDate = DateTime.Now,
                AuthorId = this.User.Identity.GetUserId(),
                NewsId = comment.NewsId
            };

            var news = this.Data.News.All()
                .FirstOrDefault(n => n.Id == newComment.NewsId);
            news.Comments.Add(newComment);
            this.Data.SaveChanges();
            //this.Data.Comments.Add(newComment);

            return this.RedirectToAction("ShowComments", new { id = news.Id });
        }
    }
}