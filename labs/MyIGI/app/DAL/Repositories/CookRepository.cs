using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CookRepository : IRepository<Cook>
{
    private readonly DatabaseContext _database;

    public CookRepository(DatabaseContext database)
    {
        _database = database;
    }

    public IEnumerable<Cook> GetAll()
    {
        return _database.Cooks;
    }

    public Cook? Get(int id)
    {
        return _database.Cooks.Find(id);
    }

    public IEnumerable<Cook> Find(Func<Cook, bool> predicate)
    {
        return _database.Cooks.Where(predicate).ToList();
    }

    public void Create(Cook item)
    {
        _database.Cooks.Add(item);
    }

    public void Update(Cook item)
    {
        _database.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var cook = _database.Cooks.Find(id);
        if (cook != null) _database.Cooks.Remove(cook);
    }

    public void Save()
    {
        _database.SaveChanges();
    }
}