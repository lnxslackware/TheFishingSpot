using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TheFishingSpot.Web.Areas.News.Models;
using TheFishingSpot.Models;
using TheFishingSpot.Data;

namespace TheFishingSpot.Web.Areas.News.Controllers
{
    public class NewsController : Controller
    {
        
        IFishingSpotData data;

        public NewsController(IFishingSpotData data)
        {
            this.data = data;
        }

        // GET: News/Home
        public ActionResult Index()
        {
            var allNews = this.data.News.All().OrderByDescending(n => n.PublishDate);
            return View(allNews.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add(NewsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = new TheFishingSpot.Models.News()
                {
                    Title = model.Title,
                    Content = model.Content,
                    PublishDate = DateTime.Now,
                    AuthorId = this.User.Identity.GetUserId()
                };
                this.data.News.Add(news);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Error = ModelState;
            return View("Create", model);
        }

        public ActionResult ShowDetails(int id)
        {
            var newsToDisplay = this.data.News.All().FirstOrDefault(n => n.Id == id);
            if (newsToDisplay == null)
            {
                ViewBag.Error = "No news found";
                return RedirectToAction("Index");
            }

            var viewModel = new NewsDetailedViewModel
            {
                Id = newsToDisplay.Id,
                Title = newsToDisplay.Title,
                Content = newsToDisplay.Content,
                PublishDate = newsToDisplay.PublishDate,
                AuthorName = newsToDisplay.Author.UserName,
                Comments = newsToDisplay.Comments.AsQueryable().Select(CommentViewModel.FromComment).ToList()
            };

            return View(viewModel);
        }

        public ActionResult ShowComments(int id)
        {
            var comments = this.data.News.All().FirstOrDefault(n => n.Id == id)
                .Comments.AsQueryable().Select(CommentViewModel.FromComment).ToList();
            if (comments == null)
            {
                ViewBag.Error = "Unallowed call";
                return RedirectToAction("Index");
            }

            //return this.Content("test");
            return PartialView("_ShowComments", comments);
        }
    }
}