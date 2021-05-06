using AutoMapper;
using GenericForum.Model.Entity;
using GenericForum.Model.Response;

namespace GenericForum.Domain.Services.Mapping
{
    public class EntityToDTOMappingProfile : Profile
    {

        public EntityToDTOMappingProfile()
        {

            CreateMap<ClientEntity, ClientResponse>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID));

            CreateMap<ClientEntity, ProfileResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Biografia, opt => opt.MapFrom(s => s.Profile.Biografia))
                .ForMember(d => d.TopicBrief, opt => opt.MapFrom(s => s.Topics));

            CreateMap<CommentEntity, CommentResponse>()
                .ForMember(d => d.CommentText, opt => opt.MapFrom(s => s.CommentText))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.CreationDate))
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Client));

            CreateMap<TopicEntity, TopicBriefResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Subtitle, opt => opt.MapFrom(s => s.Subtitle))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.CreationDate))
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Client));

            CreateMap<TopicEntity, TopicResponse>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Subtitle, opt => opt.MapFrom(s => s.Subtitle))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.CreationDate))
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Client));



        }

    }
}
