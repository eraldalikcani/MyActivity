using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;
using MediatR;
using Application.Activities;
using Application.Core;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions;

//we use static because we don't have to create a new instance class when we use extention method
public static class ApplicationServiceExtentions
{
    //static method
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
         IConfiguration config) {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);    

            return services;
    } 
}
