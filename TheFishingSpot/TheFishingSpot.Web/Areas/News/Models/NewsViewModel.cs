namespace TheFishingSpot.Web.Areas.News.Models
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;
    
    using TheFishingSpot.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<TheFishingSpot.Models.News>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TheFishingSpot.Models.News, NewsViewModel>()
                .ForMember(vm => vm.AuthorName, opt => opt.MapFrom(n => n.Author.UserName));
        }
    }
}