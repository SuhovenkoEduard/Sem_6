using ClassLibrary.CSV;
using ClassLibrary.Entities;
using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository.SCVsRepository
{
    public class CsvRepUser : IRepository<User>
    {
        private static readonly string path = @"D:\Projects\University\Semester 6\Sem_6\IGI\Lab 1\CSVs\users.csv";

        public void Delete(int id)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<User>(path);

            List<User> res = new List<User>();
            foreach (var item in lst)
            {
                if (item.Id != id)
                    res.Add(item);
            }

            csv.WriteFile(path, res);
        }

        public void Insert(User entity)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<User>(path);

            List<User> res = new List<User>();
            res.Add(entity);

            csv.WriteFile(path, res);

        }

        public List<User> Search(string login)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<User>(path);
            var res = new List<User>();

            foreach (var item in lst)
            {
                if (item.Login == login)
                    res.Add(item);

            }
            return res;
        }

        public List<User> SelectAll()
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<User>(path);
            return lst.ToList();
        }
    }
}
