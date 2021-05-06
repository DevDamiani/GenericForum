using AutoMapper;
using GenericForum.API.Helper;
using GenericForum.Domain.Services.Mapping;
using GenericForum.Logic.Services;
using GenericForum.Model.Interfaces.Helpers;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Interfaces.Services;
using GenericForum.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GenericForum.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<ForumGenericContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("ForumGeneric"))
            );

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToDTOMappingProfile>();
                cfg.AddProfile<DTOToEntityMappingProfile>();
            });
            var mapper = config.CreateMapper();


            services.AddSingleton(mapper);

            services.AddTransient<ITokenHelper, TokenHelperHandler>();

            services.AddScoped<IAuthService, AuthServiceHandler>();
            services.AddScoped<IClientService, ClientServiceHandler>();
            services.AddScoped<IProfileService, ProfileServiceHandler>();
            services.AddScoped<ITopicService, TopicServiceHandler>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();

            return services;


        }

        public static void CreateDataBase(this IServiceProvider serviceProvider)
        {

            using (var service = serviceProvider.GetRequiredService<ForumGenericContext>())
            {
                if (service.Database.EnsureCreated())
                {
                    // Insert in DB
                }
            }

            


        }


    }
}
