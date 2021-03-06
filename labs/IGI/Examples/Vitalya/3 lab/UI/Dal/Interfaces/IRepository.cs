using System;
using System.Collections.Generic;

namespace Dal.Interfaces
{
    public interface IRepository<T> where T: IEntity
    { 
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();

    }
}