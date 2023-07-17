using EBusinessData.DAL;
using EBusinessEntity.Entities.User;
using EBusinessService.Services;
using EBusinessService.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EBusinessService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this  IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IPostService,PostService>();
            services.AddScoped<IContactService,ContactService>();
            services.AddScoped<ICommentService,CommentService>();
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 5;
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstu vwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
                option.Lockout.AllowedForNewUsers = true;


            }
       ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            return services;

        }
    }
}
