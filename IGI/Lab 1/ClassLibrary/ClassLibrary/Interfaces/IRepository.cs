using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(int id);
        List<T> SelectAll();
        List<T> Search(string parametr);
    }
}
