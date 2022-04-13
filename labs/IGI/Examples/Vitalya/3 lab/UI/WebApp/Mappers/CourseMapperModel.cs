using BLL;
using Bll.Repository;
using WebApp.Models;

namespace WebApp.Mappers
{
    public static class CourseMapperModel
    {
        public static CourseModel FromDto(IModel model)
        {
            var dto = model as CourseDTO;
            return new CourseModel()
            {
                Id = dto!.Id,
                Description = dto.Description,
                CourseName = dto.CourseName,
                StudInfos = dto.StudInfos
            };
        }
        public static CourseDTO ToDto(CourseModel entity)
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