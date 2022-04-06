using System;
using System.Collections.Generic;
using Dal.Interfaces;

#nullable disable

namespace Dal
{
    public class Course : IEntity
    {
        public Course()
        {
            StudInfos = new HashSet<StudInfo>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudInfo> StudInfos { get; set; }
    }
}
