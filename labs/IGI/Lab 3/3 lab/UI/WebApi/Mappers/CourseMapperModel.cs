using BLL;
using Bll.Repository;
using WebApi.Models;

namespace WebApi.Mappers
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