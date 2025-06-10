using Data.Contexts;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Abstracts.IServices;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;

namespace BusinessLogic.Middlewares
{
    public static class CustomBuildServices
    {
        public static IServiceCollection AddDataConnections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("default")));

         

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddHttpClient<IDealService, DealService>();

            // ForumService ve AutoMapper
            services.AddAutoMapper(typeof(BusinessLogic.Services.ForumProfile));
            services.AddScoped<ForumService>();

            return services;
        }
    }
} 