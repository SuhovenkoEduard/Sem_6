using System.Linq;
using System.Text.Encodings.Web;
using Bll.Mappers;
using Bll.Services;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Mappers;
using WebApp.Models;

namespace WebApp.TagHelpers
{
    public class CourseListTagHelper : TagHelper
    {
        private StudInfoModel stud { get; set; }
        private readonly CourseService _service;
        public CourseListTagHelper(CourseService service)
        {
            _service = service;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("stud", HtmlEncoder.Default);
            var models = _service.GetData().Select(CourseMapperModel.FromDto).ToList();
            // ???
            var model = models.First(x => x.Id == stud.CourseCode);
            output.Content.SetHtmlContent($"<p>{stud.LastName}</p>" 
                                          + $"<p>{stud.MiddleName}</p>"
                                          + $"<p>{stud.Graduate}</p>"
                                          + $"<p>{stud.YearGraduate}</p>"
                                          + $"<p>{model.CourseName} </p>");
        }
    }
}