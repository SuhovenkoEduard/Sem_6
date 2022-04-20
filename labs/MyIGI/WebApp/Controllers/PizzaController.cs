using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Types;

namespace WebApp.Controllers;

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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
        // var isFromFilter = HttpContext.Request.Query["isFromFilter"] == "true";

        // _pizzaService.GetSortPagingCookiesForUserIfNull(Request.Cookies, User.Identity.Name, isFromFilter,
        //     ref page, ref sortState);
        // _pizzaService.GetFilterCookiesForUserIfNull(Request.Cookies, User.Identity.Name, isFromFilter,
        //     ref selectedName);
        // _pizzaService.SetDefaultValuesIfNull(ref selectedName, ref page, ref sortState);
        // _pizzaService.SetCookies(Response.Cookies, User.Identity.Name, selectedName, page, sortState);

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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }

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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
        return View();
    }
    
    // POST: Manufacturers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name,Caloric")] PizzaDTO pizza)
    {
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
        if (!ModelState.IsValid) return View(pizza);
        _pizzaService.Create(pizza);
        return RedirectToAction(nameof(Index));
    }
    
    // GET: Manufacturers/Edit/5
    public IActionResult Edit(int id)
    {
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
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
        // if (!User.IsInRole(Areas.Identity.Roles.Admin))
        // {
        //     return Redirect("~/Identity/Account/Login");
        // }
        _pizzaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}