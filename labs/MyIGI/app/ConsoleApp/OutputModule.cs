using BLL.Services;

namespace ConsoleApp;

public class OutputModule
{
    private readonly CookService cookService;
    private readonly PizzaService pizzaService;
    private readonly RestaurantService restaurantService;

    public OutputModule(PizzaService pizzaService, RestaurantService restaurantService, CookService cookService)
    {
        this.pizzaService = pizzaService;
        this.restaurantService = restaurantService;
        this.cookService = cookService;
    }

    public void Run()
    {
        // // db
        // var dbContext = new DatabaseContext();
        //
        // // repositories
        // var pizzaRepository = new PizzaRepository(dbContext);
        // var restaurantRepository = new RestaurantRepository(dbContext);
        // var cookRepository = new CookRepository(dbContext);
        //
        // // services
        // var pizzaService = new PizzaService(pizzaRepository);
        // var restaurantService = new RestaurantService(restaurantRepository);
        // var cookService = new CookService(cookRepository);

        // collections
        var pizzas = pizzaService.GetAll();
        var restaurants = restaurantService.GetAll();
        var cooks = cookService.GetAll();

        // output
        foreach (var pizza in pizzas)
            Console.WriteLine($"{pizza.Id}, {pizza.Name}, {pizza.Caloric}");
        Console.WriteLine();

        foreach (var restaurant in restaurants)
            Console.WriteLine($"{restaurant.Id}, {restaurant.Address}, {restaurant.Revenue}");
        Console.WriteLine();

        foreach (var cook in cooks)
            Console.WriteLine($"{cook.Id}, {cook.Name}, {cook.Age}," +
                              $"{cook.PizzaId}, {cook.RestaurantId}");
        Console.WriteLine();
    }
}