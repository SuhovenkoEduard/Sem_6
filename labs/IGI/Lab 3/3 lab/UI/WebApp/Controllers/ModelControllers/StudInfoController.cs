using System.Linq;
using Bll.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mappers;

namespace WebApp.Controllers.ModelControllers
{
    public class StudInfoController : Controller
    {
        private readonly StudInfoService _service;

        public StudInfoController(StudInfoService service)
        {
            _service = service;
        }
        
        public IActionResult Index()
        {
            var models = _service.GetData().Select(StudInfoMapperModel.FromDto).ToList();
            return View(models);
        }
        
        // [HttpGet]
        // public IActionResult StudInfoAdd()
        // {
        //     return View();
        // }
        //
        //
        // [HttpPost]
        // public IActionResult StudInfoAdd(StudInfoModel model)
        // {
        //     model.Id = AutoIndex();
        //     _service.Add(StudInfoMapperModel.ToDto(model));
        //     return Redirect("/StudInfo/Index");
        // }
        //
        // public IActionResult StudInfoUpdate(StudInfoModel model)
        // {
        //     if (Request.Method == "POST")
        //     {
        //         _service.Update(StudInfoMapperModel.ToDto(model));
        //         return Redirect("/StudInfo/Index");
        //     }
        //     return View(model);
        // }
        //
        // public IActionResult StudInfoDelete(StudInfoModel model)
        // {
        //     _service.Delete(StudInfoMapperModel.ToDto(model));
        //     return Redirect("/StudInfo/Index");
        // }
        //
        //
        // private int LastIndex()
        // {
        //     return _service.GetData().Last().Id;
        // }
        //
        // private int AutoIndex()
        // {
        //     return LastIndex() + 1;
        // }
    }
}