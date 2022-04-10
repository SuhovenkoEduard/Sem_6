using DAL.Entities;
using DAL.EntityFramework;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DiModule
{
    public static void ConfigurationDalServices(this IServiceCollection builder, string connectionString)
    {
        builder.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite(connectionString));
        // builder.AddDbContext<AuthDbContext>(options =>
        //     options.UseSqlite(connectionString));
             
        builder.AddScoped<IRepository<Pizza>, PizzaRepository>();
        builder.AddScoped<IRepository<Restaurant>, RestaurantRepository>();
        builder.AddScoped<IRepository<Cook>, CookRepository>();

        // builder.AddIdentity<IdentityUser, IdentityRole>(opts =>
        // {
        //     opts.Password.RequiredLength = 5;
        //     opts.Password.RequireNonAlphanumeric = false;
        //     opts.Password.RequireLowercase = false;
        //     opts.Password.RequireUppercase = false;
        //     opts.Password.RequireDigit = true;
        // });
            // .AddEntityFrameworkStores<AuthDbContext>();
            
        builder.AddScoped<DbContext, DatabaseContext>();
    }
}