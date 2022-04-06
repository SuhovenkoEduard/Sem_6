using System.Collections.Generic;
using System.Linq;
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
    }
}