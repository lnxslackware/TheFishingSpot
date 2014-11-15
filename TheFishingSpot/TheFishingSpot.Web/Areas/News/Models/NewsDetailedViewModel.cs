
namespace TheFishingSpot.Web.Areas.News.Models
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using TheFishingSpot.Web.Infrastructure.Mapping;

    public class NewsDetailedViewModel : IMapFrom<TheFishingSpot.Models.News>, IHaveCustomMappings
    {
        //public static Expression<Func<News, NewsDetailedViewModel>> FromNews
        //{
        //    get
        //    {
        //        return n => new NewsDetailedViewModel()
        //        {
        //            Id = n.Id,
        //            Title = n.Title,
        //            Content = n.Content,
        //            PublishDate = n.PublishDate,
        //            AuthorName = n.Author.UserName,
        //            Comments = n.Comments.AsQueryable().Select(CommentViewModel.FromComment).ToList()
        //        };
        //    }
        //}

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TheFishingSpot.Models.News, NewsDetailedViewModel>()
                .ForMember(vm => vm.AuthorName, opt => opt.MapFrom(n => n.Author.UserName));
        }
    }
}