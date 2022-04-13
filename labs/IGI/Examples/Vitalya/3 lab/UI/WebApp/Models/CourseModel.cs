using System.Collections.Generic;
using Bll;
using Dal;

namespace WebApp.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        
        public List<StudInfo> StudInfos { get; set; }
    }
}