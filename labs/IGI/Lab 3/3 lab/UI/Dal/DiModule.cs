using Dal.EF;
using Dal.Interfaces;
using Dal.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public static class DiModule
    {
        public static void ConfigurationDalServices(this IServiceCollection builder, string connectionString)
        {
            builder.AddDbContext<DatabaseContext>(options =>
                options.UseSqlite(connectionString));
            builder.AddDbContext<AuthDbContext>(options =>
                options.UseSqlite(connectionString));
            
            builder.AddScoped<IRepository<Address>, AddressRepository>();
            builder.AddScoped<IRepository<Course>, CourseRepository>();
            builder.AddScoped<IRepository<StudInfo>, StudInfoRepository>();

            builder.AddIdentity<IdentityUser, IdentityRole>((opts=> {
                    opts.Password.RequiredLength = 5;   
                    opts.Password.RequireNonAlphanumeric = false;  
                    opts.Password.RequireLowercase = false; 
                    opts.Password.RequireUppercase = false; 
                    opts.Password.RequireDigit = true; 
                }))
                .AddEntityFrameworkStores<AuthDbContext>();
            
            
            builder.AddScoped<DbContext, DatabaseContext>();
        }
    }
}