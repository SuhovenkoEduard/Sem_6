using System;
using System.Collections.Generic;
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

        public int Id { get; set; }
        public string ExistAddress { get; set; }

        public virtual ICollection<StudInfo> StudInfos { get; set; }
    }
}
