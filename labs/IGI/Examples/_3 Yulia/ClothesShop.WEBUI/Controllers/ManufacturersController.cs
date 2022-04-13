using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesShop.BLL.DTO;
using ClothesShop.BLL.Services;
using ClothesShop.WEBUI.EntityServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.WEBUI.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly ManufacturerService _manufacturersService;
        private readonly ManufacturerEntityService _service;
        private readonly int _pageSize;

        public ManufacturersController(ManufacturerService manufacturersService)
        {
            _manufacturersService = manufacturersService; 
            _service = new ManufacturerEntityService();
            _pageSize = 8;
        }

        // GET: Manufacturers
        public IActionResult Index(string selectedName, int? page, ManufacturerEntityService.SortState? sortState)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            bool isFromFilter = HttpContext.Request.Query["isFromFilter"] == "true";

            _service.GetSortPagingCookiesForUserIfNull(Request.Cookies, User.Identity.Name, isFromFilter,
                ref page, ref sortState);
            _service.GetFilterCookiesForUserIfNull(Request.Cookies, User.Identity.Name, isFromFilter,
                ref selectedName);
            _service.SetDefaultValuesIfNull(ref selectedName, ref page, ref sortState);
            _service.SetCookies(Response.Cookies, User.Identity.Name, selectedName, page, sortState);

            var manufacturers = _manufacturersService.Get().AsQueryable();

            manufacturers = _service.Filter(manufacturers, selectedName);

            var count = manufacturers.Count();

            manufacturers = _service.Sort(manufacturers, (ManufacturerEntityService.SortState)sortState);
            manufacturers = _service.Paging(manufacturers, isFromFilter, (int)page, _pageSize);

            ViewModels.Manufacturer.IndexManufacturerViewModel model = new ViewModels.Manufacturer.IndexManufacturerViewModel
            {
                Manufacturers = manufacturers.ToList(),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize),
                FilterManufacturerViewModel = new ViewModels.Manufacturer.FilterManufacturerViewModel(selectedName),
                SortManufacturerViewModel = new ViewModels.Manufacturer.SortManufacturerViewModel((ManufacturerEntityService.SortState)sortState),
            };

            return View(model);
        }

        // GET: Manufacturers/Details/5
        public IActionResult Details(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturersService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public IActionResult Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Id")] ManufacturerDTO manufacturer)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (ModelState.IsValid)
            {
                _manufacturersService.Create(manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturersService.Get((int)id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Description,Id")] ManufacturerDTO manufacturer)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _manufacturersService.Update(manufacturer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = _manufacturersService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            _manufacturersService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _manufacturersService.Exists(id);
        }
    }
}
