using Bll.Services;
using Dal;
using Microsoft.Extensions.DependencyInjection;
namespace Bll
{
    public static class DllDiModule
    {
        private static void ConfigurationManagers(IServiceCollection service)
        {
            service.AddScoped<AddressService>();
            service.AddScoped<CourseService>();
            service.AddScoped<StudInfoService>();
        }
        
        public static void ConfigurationBllManagers(this IServiceCollection builder, string connectionString)
        {
            builder.ConfigurationDalServices(connectionString);
            ConfigurationManagers(builder); 
        }
    }
}