using System;
using System.Collections.Generic;
using Bll;
using Bll.Repository;
using Dal;

namespace BLL
{
    public class CourseDTO : IModel
    {

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        
        public List<StudInfo> StudInfos { get; set; }
        

    }
}
