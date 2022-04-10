using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DIModule
{
    public static void ConfigurationDalServices(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite(connectionString));
        // builder.AddDbContext<AuthDbContext>(options =>
        //     options.UseSqlite(connectionString));

        serviceCollection.AddScoped<IRepository<Pizza>, PizzaRepository>();
        serviceCollection.AddScoped<IRepository<Restaurant>, RestaurantRepository>();
        serviceCollection.AddScoped<IRepository<Cook>, CookRepository>();

        // builder.AddIdentity<IdentityUser, IdentityRole>(opts =>
        // {
        //     opts.Password.RequiredLength = 5;
        //     opts.Password.RequireNonAlphanumeric = false;
        //     opts.Password.RequireLowercase = false;
        //     opts.Password.RequireUppercase = false;
        //     opts.Password.RequireDigit = true;
        // });
        // .AddEntityFrameworkStores<AuthDbContext>();

        serviceCollection.AddScoped<DbContext, DatabaseContext>();
    }
}