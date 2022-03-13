using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class User : IPropertys
    {
        public int Id { get; set; }
        public string Login {set;get;}
        public string Password { set; get; }
        public string Rank { get; set; }

        public void SetValue(string[] props)
        {
            this.Id = int.Parse(props[0]);
            this.Login = props[1];
            this.Password = props[2];
            this.Rank = props[3];
        }

        public override string ToString()
        {
            return Id + " " + Login + " " + Password + " " + Rank;
        }
    }
}
