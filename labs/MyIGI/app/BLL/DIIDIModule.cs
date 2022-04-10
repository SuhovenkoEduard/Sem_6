using BLL.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DIIDIModule
{
    public static void ConfigurationBllManagers(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.ConfigurationDalServices(connectionString);
        serviceCollection.AddScoped<PizzaService>();
        serviceCollection.AddScoped<RestaurantService>();
        serviceCollection.AddScoped<CookService>();
    }
}