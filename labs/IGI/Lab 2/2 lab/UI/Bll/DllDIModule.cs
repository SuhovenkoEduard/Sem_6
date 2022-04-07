using Bll.Repository;
using Bll.Services;
using Dal;
using Microsoft.Extensions.DependencyInjection;
namespace Bll
{
    public class DllDIModule
    {
        public static void ConfigurareManagers(IServiceCollection service)
        {
            service.AddScoped<AddressService>();
            service.AddScoped<CourseService>();
            service.AddScoped<StudInfoService>();
        }
        
        public static void ConfigurateBllManagers(IServiceCollection builder, string _connectionString)
        {
          
            DiModule.ConfigurateDalServices(builder, _connectionString);
            
            ConfigurareManagers(builder); 
        }
    }
}