using System.Collections.Generic;
using BLL;
using Bll.Repository;
using Dal;
using Dal.Interfaces;

namespace Bll.Mappers
{
    public class AddressMapper
    {
        public Address FromDto(AddressDTO dto)
        {
            return new Address()
            {
                Id = dto.Id,
                ExistAddress = dto.ExistAddress
            };
        }

        public IModel ToDto(Address entity)
        {

            return new AddressDTO()
            {
                Id = entity.Id,
                ExistAddress = entity.ExistAddress
            };
        }
    }
}