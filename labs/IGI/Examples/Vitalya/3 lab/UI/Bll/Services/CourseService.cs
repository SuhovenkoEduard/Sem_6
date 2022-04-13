using System.Collections.Generic;
using System.Linq;
using BLL;
using Bll.Mappers;
using Bll.Repository;
using Dal;
using Dal.Interfaces;
using Dal.Repository;

namespace Bll.Services
{
    public class CourseService : IService
    {
        private static IRepository<Course> _repository;
        private readonly CourseMapper _mapper = new CourseMapper();

        public CourseService(IRepository<Course> courseRepository)
        {
            _repository = courseRepository;
        }

        public List<IModel> GetData()
        {
            return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
        }
        public void Add(CourseDTO dto)
        {
            _repository.Create(_mapper.FromDto(dto));
            _repository.Save();
        }

        public void Delete(CourseDTO dto)
        {
            _repository.Delete(dto.Id);
            _repository.Save();
        }

        public void Update(CourseDTO dto)
        {
            var itemUpdate = _repository.Get(dto.Id);
            itemUpdate.CourseName = dto.CourseName;
            itemUpdate.Description = dto.Description;
            _repository.Update(itemUpdate);
            _repository.Save();
        }

    }
}