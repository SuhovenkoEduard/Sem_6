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
    public class AddressService : IService
    {
        private static IRepository<Address> _repository;
        private readonly AddressMapper _mapper = new AddressMapper();
    
        
        public AddressService(IRepository<Address> address)
        {
            _repository = address;
        }

        public string GetAddress()
        {

            return string.Join(',', _repository.GetAll().Select(address => address.ExistAddress));
        }
        public List<IModel> GetData()
        {
            return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
        }

        public void Add(AddressDTO dto)
        {
            _repository.Create(_mapper.FromDto(dto));
            _repository.Save();
        }

        public void Delete(AddressDTO dto)
        {
            _repository.Delete(dto.Id);
            _repository.Save();
        }

        public void Update(AddressDTO dto)
        {
            var itemUpdate = _repository.Get(dto.Id);
            itemUpdate.ExistAddress = dto.ExistAddress;
            _repository.Update(itemUpdate);
            _repository.Save();
        }

        public List<Address> Find(AddressDTO dto)
        {
            var entity = _mapper.FromDto(dto);
            return _repository.Find(entity => entity.Id == dto.Id &&
                                              entity.ExistAddress == dto.ExistAddress).ToList();
        }
    }
}