using System.Linq;
using Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mappers;
using WebApp.Models;

namespace WebApp.Controllers.ModelControllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
        }
        
        public IActionResult Index()
        {
            var models = _service.GetData().Select(CourseMapperModel.FromDto).ToList();
            return View(models);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CourseAdd()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CourseAdd(CourseModel model)
        {
            model.Id = AutoIndex();
            _service.Add(CourseMapperModel.ToDto(model));
            return RedirectToAction(actionName: "Index");
        }
        
        [Authorize(Roles = "Admin, Moder")]
        public IActionResult CourseUpdate(CourseModel model)
        {
            if (Request.Method == "POST")
            {
                _service.Update(CourseMapperModel.ToDto(model));
                return RedirectToAction(actionName: "Index");
            }
            return View(model);
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult CourseDelete(CourseModel model)
        {
            _service.Delete(CourseMapperModel.ToDto(model));
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