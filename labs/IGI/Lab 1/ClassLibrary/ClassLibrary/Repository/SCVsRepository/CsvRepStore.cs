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
    public class CsvRepStore : IRepository<Store>
    {
        private static readonly string path = @"D:\Projects\University\Semester 6\Sem_6\IGI\Lab 1\CSVs\store.csv";

        public void Delete(int id)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Store>(path);

            List<Store> res = new List<Store>();
            foreach (var item in lst)
            {
                if (item.Id != id)
                    res.Add(item);
            }

            csv.WriteFile(path, res);
        }

        public void Insert(Store entity)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Store>(path);

            List<Store> res = new List<Store>();
            res.Add(entity);

            csv.WriteFile(path, res);

        }

        public List<Store> Search(string nameTovar)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Store>(path);
            var res = new List<Store>();

            foreach (var item in lst)
            {
                if (item.NameTovar == nameTovar)
                    res.Add(item);

            }

            return res;
        }

        public List<Store> SelectAll()
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Store>(path);
            return lst.ToList();
        }
    }
}
