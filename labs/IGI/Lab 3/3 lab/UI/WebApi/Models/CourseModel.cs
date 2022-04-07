using System.Collections.Generic;
using Bll;
using Dal;

namespace WebApi.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        
    }
}