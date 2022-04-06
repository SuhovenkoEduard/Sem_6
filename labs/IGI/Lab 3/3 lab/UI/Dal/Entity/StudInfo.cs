using System;
using System.Collections.Generic;
using Dal.Interfaces;

#nullable disable

namespace Dal
{
    public class StudInfo : IEntity
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public int? CourseCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string DateEnrolled { get; set; }
        public string YearGraduate { get; set; }
        public string Graduate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Course CourseCodeNavigation { get; set; }
    }
}
