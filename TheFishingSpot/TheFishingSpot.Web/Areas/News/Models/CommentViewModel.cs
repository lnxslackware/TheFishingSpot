namespace TheFishingSpot.Web.Areas.News.Models
{
    using System;
    using System.Linq.Expressions;

    using AutoMapper;

    using TheFishingSpot.Models;
    using TheFishingSpot.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(vm => vm.AuthorName, opt => opt.MapFrom(n => n.Author.UserName));
        }
    }
}