using AutoMapper;
using GenericForum.Model.Entity;
using GenericForum.Model.Request;
using System;

namespace GenericForum.Domain.Services.Mapping
{
    public class DTOToEntityMappingProfile : Profile
    {

        public DTOToEntityMappingProfile()
        {
            CreateMap<CreateClientRequest, ClientEntity>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => DateTime.Now));

            CreateMap<TopicRequest, TopicEntity>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(d => d.Subtitle, opt => opt.MapFrom(s => s.Subtitle));

            CreateMap<CommentRequest, CommentEntity>()
                .ForMember(d => d.TopicId, opt => opt.MapFrom(s => s.TopicID))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(d => d.CommentText, opt => opt.MapFrom(s => s.CommentText));
               
        }

    }
}
