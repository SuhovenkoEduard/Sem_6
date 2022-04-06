using System;
using System.Collections.Generic;
using Bll.Repository;


namespace BLL
{
    public class AddressDTO : IModel
    {
        public int Id { get; set; }
        public string ExistAddress { get; set; }
    }
}
