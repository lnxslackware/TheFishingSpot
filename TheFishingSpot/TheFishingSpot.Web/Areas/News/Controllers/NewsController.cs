namespace TheFishingSpot.Web.Areas.News.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;

    using TheFishingSpot.Data;
    using TheFishingSpot.Web.Areas.News.Models;
    using TheFishingSpot.Web.Controllers;
    using TheFishingSpot.Web.Infrastructure;
    using PagedList;

    public class NewsController : BaseController
    {
        private readonly ISanitizer sanitizer;
        private const int DefaultPageSize = 2;
        private const int PreviewNewsContentDisplayLength = 200;

        public NewsController(IFishingSpotData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        // GET: News/Home
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var allNews = this.Data.News.All()
                .OrderByDescending(n => n.PublishDate)
                .Project()
                .To<NewsViewModel>()
                //.Skip((page - 1) * DefaultPageSize)
                /*.Take(DefaultPageSize)*/.ToList();

            //allNews.ForEach(n => n.Content = TrimAndSanitizeContent(n.Content));

            var pagedList = new PagedList<NewsViewModel>(allNews, page, DefaultPageSize);

            return View(pagedList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NewsInputViewModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewsInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = new TheFishingSpot.Models.News()
                {
                    Title = model.Title,
                    Content = sanitizer.Sanitize(model.Content),
                    PublishDate = DateTime.Now,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.Data.News.Add(news);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Error = true;
            return View("Create", model);
        }

        [HttpGet]
        public ActionResult ShowDetails(int id)
        {
            var newsToDisplay = this.Data.News.All().Where(n => n.Id == id);
            if (newsToDisplay == null)
            {
                ViewBag.Error = "No news found";
                return RedirectToAction("Index");
            }

            var viewModel = newsToDisplay.Project().To<NewsDetailedViewModel>().FirstOrDefault();
            //var viewModel = new NewsDetailedViewModel
            //{
            //    Id = newsToDisplay.Id,
            //    Title = newsToDisplay.Title,
            //    Content = newsToDisplay.Content,
            //    PublishDate = newsToDisplay.PublishDate,
            //    AuthorName = newsToDisplay.Author.UserName,
            //    Comments = newsToDisplay.Comments
            //        .AsQueryable()
            //        .Project().To<CommentViewModel>().ToList()//.Select(CommentViewModel.FromComment).ToList()
            //};

            return View(viewModel);
        }


        [NonAction]
        private string TrimAndSanitizeContent(string content)
        {
            content = this.sanitizer.Sanitize(content);
            if (content.Length > PreviewNewsContentDisplayLength)
            {
                return content.Substring(0, 200) + "...";
            }

            return content + "...";
        }
    }
}