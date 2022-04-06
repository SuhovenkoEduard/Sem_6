using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dal.Interfaces;

#nullable disable

namespace Dal
{
    public class Address : IEntity
    {
        public Address()
        {
            StudInfos = new HashSet<StudInfo>();
        }

        [Key]
        public int Id { get; set; }
        public string ExistAddress { get; set; }

        public virtual ICollection<StudInfo> StudInfos { get; set; }
    }
}
