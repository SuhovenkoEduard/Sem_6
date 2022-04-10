using DAL.Entities;

namespace DAL.Interfaces;

public interface IRepository<T> 
    where T: IEntity
{
    IEnumerable<T> GetAll();
    T? Get(int id);
    IEnumerable<T> Find(Func<T, bool> predicate);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
    void Save();
}