using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClothesShop.BLL.Services;
using ClothesShop.WEBUI.EntityServices;
using ClothesShop.BLL.DTO;

namespace ClothesShop.WEBUI.Controllers
{
    public class ClothingItemsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClothingItemService _clothingItemService;
        ManufacturerService _manufacturerService;
        ClothingItemTypeService _clothingItemTypeService;
        private readonly ClothingItemEntityService _service;
        private readonly int _pageSize;

        public ClothingItemsController(ClothingItemService clothingItemService, ManufacturerService manufacturerService,
            ClothingItemTypeService clothingItemTypeService, UserManager<IdentityUser> userManager)
        {
            _clothingItemService = clothingItemService;
            _manufacturerService = manufacturerService;
            _clothingItemTypeService = clothingItemTypeService;

            _userManager = userManager;
            _service = new ClothingItemEntityService();
            _pageSize = 5;
        }

        // GET: ClothingItems
        public IActionResult Index(string selectedName, int? page, ClothingItemEntityService.SortState? sortState)
        {
            if (!User.IsInRole(Areas.Identity.Roles.User) && !User.IsInRole(Areas.Identity.Roles.Admin))
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

            var clothingItems = _clothingItemService.Get()
                .AsQueryable();

            clothingItems = _service.Filter(clothingItems, selectedName);

            var count = clothingItems.Count();

            clothingItems = _service.Sort(clothingItems, (ClothingItemEntityService.SortState)sortState);
            clothingItems = _service.Paging(clothingItems, isFromFilter, (int)page, _pageSize);

            ViewModels.ClothingItem.IndexClothingItemViewModel model = new ViewModels.ClothingItem.IndexClothingItemViewModel
            {
                ClothingItems = clothingItems.ToList(),
                PageViewModel = new ViewModels.PageViewModel(count, (int)page, _pageSize),
                FilterClothingItemViewModel = new ViewModels.ClothingItem.FilterClothingItemViewModel(selectedName),
                SortClothingItemViewModel = new ViewModels.ClothingItem.SortClothingItemViewModel((ClothingItemEntityService.SortState)sortState),
            };

            return View(model);
        }

        // GET: ClothingItems/Details/5
        public IActionResult Details(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.User) && !User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return Redirect("~/Identity/Account/Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = _clothingItemService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (clothingItem == null)
            {
                return NotFound();
            }

            return View(clothingItem);
        }

        // GET: ClothingItems/Create
        public IActionResult Create()
        {
            if(!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.Get(), "Id", "Name");
            ViewData["ClothingItemTypeId"] = new SelectList(_clothingItemTypeService.Get(), "Id", "Name");
            return View();
        }

        // POST: ClothingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClothingItemTypeId,ManufacturerId,Name,Description,Size,IsMale,Price,Id")] ClothingItemDTO clothingItem)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                _clothingItemService.Create(clothingItem);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.Get(), "Id", "Name", clothingItem.ManufacturerId);
            ViewData["ClothingItemTypeId"] = new SelectList(_clothingItemTypeService.Get(), "Id", "Name", clothingItem.ClothingItemTypeId);
            return View(clothingItem);
        }

        // GET: ClothingItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = _clothingItemService.Get((int)id);
            if (clothingItem == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.Get(), "Id", "Name", clothingItem.ManufacturerId);
            ViewData["ClothingItemTypeId"] = new SelectList(_clothingItemTypeService.Get(), "Id", "Name", clothingItem.ClothingItemTypeId);
            return View(clothingItem);
        }

        // POST: ClothingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ClothingItemTypeId,ManufacturerId,Name,Description,Size,IsMale,Price,Id")] ClothingItemDTO clothingItem)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id != clothingItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clothingItemService.Update(clothingItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingItemExists(clothingItem.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_manufacturerService.Get(), "Id", "Name", clothingItem.ManufacturerId);
            ViewData["ClothingItemTypeId"] = new SelectList(_clothingItemTypeService.Get(), "Id", "Name", clothingItem.ClothingItemTypeId);
            return View(clothingItem);
        }

        // GET: ClothingItems/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = _clothingItemService.Get()
                .FirstOrDefault(m => m.Id == id);
            if (clothingItem == null)
            {
                return NotFound();
            }

            return View(clothingItem);
        }

        // POST: ClothingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!User.IsInRole(Areas.Identity.Roles.Admin))
            {
                return RedirectToAction("Index", "Home");
            }
            _clothingItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingItemExists(int id)
        {
            return _clothingItemService.Exists(id);
        }
    }
}
