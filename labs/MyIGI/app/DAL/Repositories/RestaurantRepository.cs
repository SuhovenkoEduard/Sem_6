using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RestaurantRepository : IRepository<Restaurant>
{
    private readonly DatabaseContext _database;

    public RestaurantRepository(DatabaseContext database)
    {
        _database = database;
    }

    public IEnumerable<Restaurant> GetAll()
    {
        return _database.Restaurants;
    }

    public Restaurant? Get(int id)
    {
        return _database.Restaurants.Find(id);
    }

    public IEnumerable<Restaurant> Find(Func<Restaurant, bool> predicate)
    {
        return _database.Restaurants.Where(predicate).ToList();
    }

    public void Create(Restaurant item)
    {
        _database.Restaurants.Add(item);
    }

    public void Update(Restaurant item)
    {
        _database.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var restaurant = _database.Restaurants.Find(id);
        if (restaurant != null) _database.Restaurants.Remove(restaurant);
    }

    public void Save()
    {
        _database.SaveChanges();
    }
}