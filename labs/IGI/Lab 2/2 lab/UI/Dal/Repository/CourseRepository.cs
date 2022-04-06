using System;
using System.Collections.Generic;
using System.Linq;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly databaseContext _database;

        public CourseRepository(databaseContext database)
        {
            _database = database;
        }
        
        public IEnumerable<Course> GetAll()
        {
            return _database.Courses;
        }

        public Course Get(int id)
        {
            return _database.Courses.Find(id);
        }

        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            return _database.Courses.Where(predicate).ToList();
        }

        public void Create(Course item)
        {
            _database.Courses.Add(item);
        }

        public void Update(Course item)
        {
            _database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Course course = _database.Courses.Find(id);
            if (course != null)
            {
                _database.Courses.Remove(course);
            }
        }

        public void Save()
        {
            _database.SaveChanges();
        }
    }
}