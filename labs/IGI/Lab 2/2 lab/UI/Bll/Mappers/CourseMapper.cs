using BLL;
using Bll.Repository;
using Dal;
using Dal.Interfaces;

namespace Bll.Mappers
{
    public class CourseMapper
    {
        public Course FromDto(CourseDTO dto)
        {
            return new Course()
            {
                Id = dto.Id,
                Description = dto.Description,
                CourseName = dto.CourseName
            };
        }
        public IModel ToDto(Course entity)
        {

            return new CourseDTO()
            {
                Id = entity.Id,
                Description = entity.Description,
                CourseName = entity.CourseName
            };
        }
    }
}