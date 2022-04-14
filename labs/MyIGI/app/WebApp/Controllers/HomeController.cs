using System.Diagnostics;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IService<PizzaDTO> _pizzaService;
    
    public HomeController(ILogger<HomeController> logger, IService<PizzaDTO> pizzaService)
    {
        _logger = logger;
        _pizzaService = pizzaService;
    }

    public IActionResult Index()
    {
        return View(_pizzaService.GetAll());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}