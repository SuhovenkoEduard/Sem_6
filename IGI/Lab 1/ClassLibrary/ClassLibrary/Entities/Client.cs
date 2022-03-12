using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Client : IPropertys
    {  
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }

        public void SetValue(string[] props)
        {
            this.Id = int.Parse(props[0]);
            this.ClientName = props[1];
            this.Surname = props[2];
            this.Surname = props[3];
            this.Age = int.Parse(props[4]);
            // this.UserId = int.Parse(props[5]);
        }

        public override string ToString()
        {
            return Id + " " + ClientName + " " + Surname + " " + Age + " " + UserId;
        }
    }
}
