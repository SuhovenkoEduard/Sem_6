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
    public class ClothingItemTypesController : Controller
    {
        private readonly ClothingItemTypeService _clothingItemTypeService;
        private readonly ClothingItemTypeEntityService _service;
        private readonly int _pageSize;

        public ClothingItemTypesController(ClothingItemTypeService clothingItemTypeService)
        {
            _clothingItemTypeService = clothingItemTypeService;
            _service = new ClothingItemTypeEntityService();
            _pageSize = 6;
        }

        // GET: ClothingItemTypes
        public IActionResult Index(string selectedName, int? page, ClothingItemTypeEntityService.SortState? sortState)
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

            var clothingItemTypes = _clothingItemTypeService.Get().AsQueryable();

            clothingItemTypes = _service.Filter(clothingItemTypes, selectedName);

            var count = clothingItemTypes.Count();

            clothingItemTypes = _service.Sort(clothingItemTypes, (ClothingItemTypeEntityService.SortState)sortState);
            clothingItemTypes = _service.Paging(clothingItemTypes, isFromFilter, (int)page, _pageSize);

            ViewModels.ClothingItemType.IndexClothingItemTypeViewModel model = new ViewModels.ClothingItemType.IndexClothingItemTypeViewModel
            {
                ClothingItemTypes = clothingItemTypes.ToList(),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize),
                FilterClothingItemTypeViewModel = new ViewModels.ClothingItemType.FilterClothingItemTypeViewModel(selectedName),
                SortClothingItemTypeViewModel = new ViewModels.ClothingItemType.SortClothingItemTypeViewModel((ClothingItemTypeEntityService.SortState)sortState),
            };

            return View(model);
        }

        // GET: ClothingItemTypes/Details/5
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

            var clothingItemType = _clothingItemTypeService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (clothingItemType == null)
            {
                return NotFound();
            }

            return View(clothingItemType);
        }

        // GET: ClothingItemTypes/Create
        public IActionResult Create()
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            return View();
        }

        // POST: ClothingItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Id")] ClothingItemTypeDTO clothingItemType)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (ModelState.IsValid)
            {
                _clothingItemTypeService.Create(clothingItemType);
                return RedirectToAction(nameof(Index));
            }
            return View(clothingItemType);
        }

        // GET: ClothingItemTypes/Edit/5
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

            var clothingItemType = _clothingItemTypeService.Get((int)id);
            if (clothingItemType == null)
            {
                return NotFound();
            }
            return View(clothingItemType);
        }

        // POST: ClothingItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Description,Id")] ClothingItemTypeDTO clothingItemType)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id != clothingItemType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clothingItemTypeService.Update(clothingItemType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingItemTypeExists(clothingItemType.Id))
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
            return View(clothingItemType);
        }

        // GET: ClothingItemTypes/Delete/5
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

            var clothingItemType = _clothingItemTypeService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (clothingItemType == null)
            {
                return NotFound();
            }

            return View(clothingItemType);
        }

        // POST: ClothingItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            _clothingItemTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingItemTypeExists(int id)
        {
            return _clothingItemTypeService.Exists(id);
        }
    }
}
