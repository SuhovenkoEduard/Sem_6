using Bll.Repository;
using Dal;
using Dal.Interfaces;

namespace Bll.Mappers
{
    public class StudInfoMapper

    {
        public StudInfo FromDto(StudInfoDTO dto)
        {
            return new StudInfo()
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
        
        public IModel ToDto(StudInfo entity)
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