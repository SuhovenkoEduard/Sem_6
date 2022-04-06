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

            // builder.RegisterModule(new RepairCompanyManagement.DataAccess.DiModule(_connectionString));

            // here we should add our BusinessLogic services
            // to manipulate on repositories

            /*   builder.RegisterType<BrigadeService>()
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
               builder.RegisterType<OrderService>()
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
               builder.RegisterType<UserService>()
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
               builder.RegisterType<ReportService>()
                   .AsImplementedInterfaces().InstancePerLifetimeScope();*/
        }
    }
}