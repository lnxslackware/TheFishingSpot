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

        public NewsController() : this(new TheFishingSpotData())
        {
        }

        public NewsController(IFishingSpotData data)
        {
            this.data = data;
        }

        // GET: News/Home
        public ActionResult Index()
        {
            var allNews = this.data.News.All();
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
    }
}