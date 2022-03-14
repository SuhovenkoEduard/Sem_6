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
    public class CsvRepClient : IRepository<Client>
    {
        private static readonly string path = @"D:\Projects\University\Sem_6\labs\IGI\Lab 1\CSVs\clients.csv";

        public void Delete(int id)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Client>(path);

            List<Client> res = new List<Client>();
            foreach (var item in lst)
            {
                if (item.Id != id)
                    res.Add(item);
            }

            csv.WriteFile(path, res);
        }

        public void Insert(Client entity)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Client>(path);

            List<Client> res = new List<Client>();
            res.Add(entity);

            csv.WriteFile(path, res);

        }

        public List<Client> Search(string clientName)
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Client>(path);
            var res = new List<Client>();

            foreach(var item in lst)
            {
                if (item.ClientName == clientName)
                    res.Add(item);

            }

            return res;
        }

        public List<Client> SelectAll()
        {
            CsvWorking csv = new CsvWorking();
            var lst = csv.ReadFile<Client>(path);
            return lst.ToList();
        }
    }
}
