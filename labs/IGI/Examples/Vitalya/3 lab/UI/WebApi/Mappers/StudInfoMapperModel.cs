using Bll;
using Bll.Repository;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class StudInfoMapperModel
    {
        public static StudInfoModel FromDto(IModel model)
        {
            var dto = model as StudInfoDTO;
            return new StudInfoModel()
            {
                Id = dto.Id,
                AddressId = dto.AddressId,
                CourseCode = dto.CourseCode,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Gender = dto.Gender,
                DateEnrolled = dto.DateEnrolled,
                YearGraduate = dto.YearGraduate,
                Graduate = dto.Graduate
            };
        }
        
        public static StudInfoDTO ToDto(StudInfoModel entity)
        {

            return new StudInfoDTO()
            {
                Id = entity.Id,
                AddressId = entity.AddressId,
                CourseCode = entity.CourseCode,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                Gender = entity.Gender,
                DateEnrolled = entity.DateEnrolled,
                YearGraduate = entity.YearGraduate,
                Graduate = entity.Graduate
            };
        }
    }
}