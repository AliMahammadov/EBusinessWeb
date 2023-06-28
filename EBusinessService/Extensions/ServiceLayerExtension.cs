using EBusinessService.Services;
using EBusinessService.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace EBusinessService.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension(this  IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            return services;
          
        }
    }
}
