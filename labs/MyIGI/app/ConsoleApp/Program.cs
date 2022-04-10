using DAL;
using DAL.Configs;
using DAL.EntityFramework;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

// var connectionString = Config.DbConfig();
// var serviceCollection = new ServiceCollection();
// serviceCollection.ConfigurationDalServices(connectionString);

// var serviceProvider = serviceCollection.BuildServiceProvider();
// var program = serviceProvider.GetRequiredService<Program>();

var dbContext = new DatabaseContext();
var pizzaRepository = new PizzaRepository(dbContext);
var pizzas = pizzaRepository.GetAll();
foreach (var pizza in pizzas)
{
    Console.WriteLine($"{pizza.Id}, {pizza.Name}, {pizza.Caloric}," +
                      $", {string.Join(", ", pizza.Cooks)}");
}
Console.WriteLine();

var restaurantRepository = new RestaurantRepository(dbContext);
var restaurants = restaurantRepository.GetAll();
foreach (var restaurant in restaurants)
{
    Console.WriteLine($"{restaurant.Id}, {restaurant.Address}, {restaurant.Revenue}," +
                      $", {string.Join(", ", restaurant.Cooks)}");
}
Console.WriteLine();

var cooksRepository = new CookRepository(dbContext);
var cooks = cooksRepository.GetAll();
foreach (var cook in cooks)
{
    Console.WriteLine($"{cook.Id}, {cook.Name}, {cook.Age}," +
                      $"{cook.PizzaId}, {cook.RestaurantId}");
}
Console.WriteLine();