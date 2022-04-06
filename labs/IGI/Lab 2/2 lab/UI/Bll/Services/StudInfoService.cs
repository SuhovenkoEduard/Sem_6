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
    }
}