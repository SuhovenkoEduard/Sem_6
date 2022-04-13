using System.Linq;
using System.Text.Encodings.Web;
using Bll.Services;
using Dal;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Mappers;
using WebApp.Models;

namespace WebApp.TagHelpers
{
    public class CourseTagHelper : TagHelper
    {
        public StudInfoModel stud { get; set; }
        private readonly CourseService _service;
        public CourseTagHelper(CourseService service)
        {
            _service = service;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("stud", HtmlEncoder.Default);
            output.Attributes.Add("style", "display:none");
            var models = _service.GetData().Select(CourseMapperModel.FromDto).ToList();
            var model = models.First(x => x.Id == stud.CourseCode);
            output.Content.SetHtmlContent($"<p>Last Name: {stud.LastName}</p>" 
                                          + $"<p>Middle Name: {stud.MiddleName}</p>"
                                          + $"<p>Graduate: {stud.Graduate}</p>"
                                          + $"<p>Year Graduate: {stud.YearGraduate}</p>"
                                          + $"<p>Course: {model.CourseName} </p>");
        }
    }
}