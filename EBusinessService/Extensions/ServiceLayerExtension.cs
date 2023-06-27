using EBusinessService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EBusinessService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this  IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            return services;
          
        }
    }
}
