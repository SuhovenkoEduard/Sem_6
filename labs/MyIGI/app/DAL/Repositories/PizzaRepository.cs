using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PizzaRepository : IRepository<Pizza>
{
    private readonly DatabaseContext _database;

    public PizzaRepository(DatabaseContext database)
    {
        _database = database;
    }

    public IEnumerable<Pizza> GetAll()
    {
        return _database.Pizzas;
    }

    public Pizza? Get(int id)
    {
        return _database.Pizzas.Find(id);
    }

    public IEnumerable<Pizza> Find(Func<Pizza, bool> predicate)
    {
        return _database.Pizzas.Where(predicate).ToList();
    }

    public void Create(Pizza item)
    {
        _database.Pizzas.Add(item);
    }

    public void Update(Pizza item)
    {
        _database.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var pizza = _database.Pizzas.Find(id);
        if (pizza != null) _database.Pizzas.Remove(pizza);
    }

    public void Save()
    {
        _database.SaveChanges();
    }
}