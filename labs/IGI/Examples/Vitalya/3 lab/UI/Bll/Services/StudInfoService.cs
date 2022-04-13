using System.Collections.Generic;
using System.Linq;
using Bll.Mappers;
using Bll.Repository;
using Dal;
using Dal.Interfaces;
using Dal.Repository;

namespace Bll.Services
{
    public class StudInfoService : IService
    {
        private static IRepository<StudInfo> _repository;
        private readonly StudInfoMapper _mapper = new StudInfoMapper();
    
        public StudInfoService(IRepository<StudInfo> studinfoRepository)
        {
            _repository = studinfoRepository;
        }
        public List<IModel> GetData()
        {
            return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
        }
        public void Add(StudInfoDTO dto)
        {
            _repository.Create(_mapper.FromDto(dto));
            _repository.Save();
        }

        public void Delete(StudInfoDTO dto)
        {
            _repository.Delete(dto.Id);
            _repository.Save();
        }

        public void Update(StudInfoDTO dto)
        {
            var itemUpdate = _repository.Get(dto.Id);
            itemUpdate.Gender = dto.Gender;
            itemUpdate.FirstName = dto.FirstName;
            itemUpdate.LastName = dto.LastName;
            itemUpdate.MiddleName = dto.MiddleName;
            itemUpdate.YearGraduate = dto.YearGraduate;
            itemUpdate.AddressId = dto.AddressId;
            itemUpdate.CourseCode = dto.CourseCode;
            
            _repository.Update(itemUpdate);
            _repository.Save();
        }
    }
}