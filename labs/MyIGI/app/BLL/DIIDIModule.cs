using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DIIDIModule
{
    public static void ConfigurationBllManagers(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.ConfigurationDalServices(connectionString);
        serviceCollection.AddScoped<IService<PizzaDTO>, PizzaService>();
        serviceCollection.AddScoped<IService<RestaurantDTO>, RestaurantService>();
        serviceCollection.AddScoped<IService<CookDTO>, CookService>();
    }
}