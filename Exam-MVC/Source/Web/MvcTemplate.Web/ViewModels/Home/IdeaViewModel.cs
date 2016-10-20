namespace MvcTemplate.Web.ViewModels.Home
{
    using AutoMapper;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/suggestions/{identifier.EncodeId(this.Id, this.Title)}";
            }
        }

        public int VotesCount { get; set; }

        public int CommentsCount { get; set; }

        public string DescriptionView
        {
            get
            {
                if (this.Description.Length > 300)
                {
                    return this.Description.Substring(0, 300) + "...";
                }

                return this.Description;
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.VotesCount, opt => opt.MapFrom(x => x.Votes.Count))
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}
