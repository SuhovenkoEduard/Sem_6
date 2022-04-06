using System;
using System.Collections.Generic;
using Bll.Repository;

namespace BLL
{
    public class CourseDTO : IModel
    {

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

    }
}
