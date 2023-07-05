using EBusinessData.DAL;
using EBusinessData.Extesions;
using EBusinessEntity.Entities.User;
using EBusinessService.Extensions;
using Microsoft.AspNetCore.Identity;

namespace EBusinessWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.LoadDataLayerExtension(builder.Configuration);
            builder.Services.LoadServiceLayerExtension();
            builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 5;
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstu vwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
                option.Lockout.AllowedForNewUsers = true;


            }
            ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}