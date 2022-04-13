using System;
using System.Collections.Generic;
using System.Linq;
using Dal.EF;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repository
{
    public class StudInfoRepository : IRepository<StudInfo>
    {
        private readonly DatabaseContext _database;

        public StudInfoRepository(DatabaseContext database)
        {
            _database = database;
        }
        
        public IEnumerable<StudInfo> GetAll()
        {
            return _database.StudInfos;
        }

        public StudInfo Get(int id)
        {
            return _database.StudInfos.Find(id);
        }

        public IEnumerable<StudInfo> Find(Func<StudInfo, bool> predicate)
        {
            return _database.StudInfos.Where(predicate).ToList();
        }

        public void Create(StudInfo item)
        {
            _database.StudInfos.Add(item);
        }

        public void Update(StudInfo item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            StudInfo studInfo = _database.StudInfos.Find(id);
            if (studInfo != null)
            {
                _database.StudInfos.Remove(studInfo);
            }
        }

        public void Save()
        {
            _database.SaveChanges();
        }
    }
}