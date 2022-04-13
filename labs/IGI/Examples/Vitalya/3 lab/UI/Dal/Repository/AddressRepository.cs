using System;
using System.Collections.Generic;
using System.Linq;
using Dal.EF;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly DatabaseContext _database;

        public AddressRepository(DatabaseContext database)
        {
            _database = database;
        }
        
        public IEnumerable<Address> GetAll()
        {
            return _database.Addresses;
        }

        public Address Get(int id)
        {
            return _database.Addresses.Find(id);
        }

        public IEnumerable<Address> Find(Func<Address, bool> predicate)
        {
            return _database.Addresses.Where(predicate).ToList();
        }

        public void Create(Address item)
        {
            _database.Addresses.Add(item);
        }

        public void Update(Address item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Address address = _database.Addresses.Find(id);
            if (address != null)
            {
                _database.Addresses.Remove(address);
            }
        }

        public void Save()
        {
            _database.SaveChanges();
        }
    }
}