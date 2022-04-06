using System.Linq;
using Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mappers;
using WebApp.Models;

namespace WebApp.Controllers.ModelControllers
    {
        public class AddressController : Controller
        {

            private readonly AddressService _service;

            public AddressController(AddressService service)
            {
                _service = service;
            }
            
            public IActionResult Index()
            {
                var models = _service.GetData().Select(AddressMapperModel.FromDto).ToList();
                return View(models);
            }
            
            [Authorize(Roles = "Admin")]
            [HttpGet]
            public IActionResult AddressAdd()
            {
                return View();
            }
            
            [Authorize(Roles = "Admin")]
            [HttpPost]
            public IActionResult AddressAdd(AddressModel model)
            {
                model.Id = AutoIndex();
                _service.Add(AddressMapperModel.ToDto(model));
                return RedirectToAction(actionName: "Index");
            }
            
            [Authorize(Roles = "Admin, Moder")]
            public IActionResult AddressUpdate(AddressModel model)
            {
                if (Request.Method == "POST")
                {
                    _service.Update(AddressMapperModel.ToDto(model));
                    return RedirectToAction(actionName: "Index");
                }
                return View(model);
            }
            
            [Authorize(Roles = "Admin")]
            public IActionResult AddressDelete(AddressModel model)
            {
                _service.Delete(AddressMapperModel.ToDto(model));
                return RedirectToAction(actionName: "Index");
            }


            private int LastIndex()
            {
                return _service.GetData().Last().Id;
            }

            private int AutoIndex()
            {
                return LastIndex() + 1;
            }
        }
    }