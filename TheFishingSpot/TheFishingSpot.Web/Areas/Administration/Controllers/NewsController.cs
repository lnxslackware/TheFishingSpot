using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using TheFishingSpot.Data;
using TheFishingSpot.Web.Areas.News.Models;
using TheFishingSpot.Web.Infrastructure.Caching;
using Kendo.Mvc.UI;

namespace TheFishingSpot.Web.Areas.Administration.Controllers
{
    public class NewsAdminController : KendoGridAdministrationController
    {
        private readonly ICacheService service;

        public NewsAdminController(IFishingSpotData data, ICacheService service)
            : base(data)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .News
                .All()
                .Project()
                .To<NewsViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.News.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            var dbModel = base.Create<NewsViewModel>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            base.Update<TheFishingSpot.Models.News, NewsViewModel>(model, model.Id);
            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var news = this.Data.News.GetById(model.Id);

                foreach (var ticketId in news.Comments.Select(t => t.Id).ToList())
                {
                    var comments = this.Data
                        .Comments
                        .All()
                        .Where(c => c.NewsId == ticketId)
                        .Select(c => c.Id)
                        .ToList();

                    foreach (var commentId in comments)
                    {
                        this.Data.Comments.Delete(commentId);
                    }

                    this.Data.SaveChanges();

                    this.Data.News.Delete(ticketId);
                }

                this.Data.SaveChanges();

                this.Data.News.Delete(news);
                this.Data.SaveChanges();
            }

            this.ClearCategoryCache();
            return this.GridOperation(model, request);
        }

        private void ClearCategoryCache()
        {
            this.service.Clear("news");
        }
    }
}