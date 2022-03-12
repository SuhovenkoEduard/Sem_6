using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Store : IPropertys
    {
        public int Id { get; set; }
        public string NameTovar { get; set; }
        public double Cost { get; set; }
        public double Count { get; set; }
        public int ClientId { get; set; }

        public void SetValue(string[] props)
        {
            this.Id = int.Parse(props[0]);
            this.NameTovar = props[1];
            this.Cost = int.Parse(props[2]);
            this.Count = int.Parse(props[3]);
            this.ClientId = int.Parse(props[4]);
        }

        public override string ToString()
        {
            return Id + " " + NameTovar + " " + Cost + " " + Count + " " + ClientId;
        }
    }
}
