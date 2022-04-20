using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Types;

namespace WebApp.Controllers;

[Authorize(Roles = "Admin")]
public class PizzaController : Controller
{
    private readonly IService<PizzaDTO> _pizzaService;

    public PizzaController(IService<PizzaDTO> pizzaService)
    {
        _pizzaService = pizzaService;
    }
    
    // GET: Manufacturers
    public IActionResult Index(IndexPizzaModel model)
    {
        if (model.Pizzas != null)
        {
            return View(model);
        }

        var res = new IndexPizzaModel()
        {
            Pizzas = _pizzaService.GetAll(),
            Filter = ""
        };
        return View(res);
    }

    // GET: Manufacturers/Details/5
    public IActionResult Details(int id)
    {
        var pizza = _pizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        
        return View(pizza);
    }

    public IActionResult Find(IndexPizzaModel indexPizzaModel)
    {
        IndexPizzaModel res;
        if (indexPizzaModel.Filter != null)
        {
            res = new IndexPizzaModel()
            {
                Pizzas = _pizzaService.GetAll().Where(pizza => pizza.Caloric >= int.Parse(indexPizzaModel.Filter)).ToList(),
                Filter = indexPizzaModel.Filter
            };
        }
        else
        {
            res = new IndexPizzaModel()
            {
                Pizzas = _pizzaService.GetAll(),
                Filter = ""
            };
        }
        return View("Index", res);
    }
    
    // GET: Manufacturers/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Manufacturers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,Caloric")] PizzaDTO pizza)
    {
        if (!ModelState.IsValid) return View(pizza);
        _pizzaService.Create(pizza);
        return RedirectToAction(nameof(Index));
    }
    
    // GET: Manufacturers/Edit/5
    public IActionResult Edit(int id)
    {
        var pizza = _pizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return View(pizza);
    }
    
    // POST: Manufacturers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,Caloric")] PizzaDTO pizza)
    {
        if (id != pizza.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid) return View(pizza);
        try
        {
            _pizzaService.Update(pizza);
        }
        catch (Exception)
        {
            if (_pizzaService.Get(id) == null)
                return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
    
    // GET: Manufacturers/Delete/5
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return View(pizza);
    }
    
    // POST: Manufacturers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _pizzaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}