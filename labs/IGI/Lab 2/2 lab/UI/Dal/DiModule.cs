using Dal.Interfaces;
using Dal.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DiModule
    {
        public static void ConfigurateDalServices(IServiceCollection builder, string _connectionString)
        {
            builder.AddDbContext<databaseContext>(options =>
                options.UseSqlite(_connectionString));

            builder.AddScoped<IRepository<Address>, AddressRepository>();
            builder.AddScoped<IRepository<Course>, CourseRepository>();
            builder.AddScoped<IRepository<StudInfo>, StudInfoRepository>();

            builder.AddScoped<DbContext, databaseContext>();
            
/*            builder.AddScoped<IRepository<Brigade>, EntityRepository.BrigadeRepository>();
            builder.AddScoped<IRepository<Employee>, EntityRepository.EmployeeRepository>();
            builder.AddScoped<IRepository<>>*/
/*
            builder.RegisterType<EFRepository<Brigade>>()
                .WithParameter("options", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.SpecializationRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.JobPositionRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.TaskRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.OrderTaskRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.OrderRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.ManagerRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.EmployeeRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.CustomerRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.BrigadeRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repositories.FeedbackRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();*/
        }
    }
}