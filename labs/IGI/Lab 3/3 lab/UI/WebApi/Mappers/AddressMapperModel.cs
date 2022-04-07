using BLL;
using Bll.Repository;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class AddressMapperModel
    {
        public static AddressModel FromDto(IModel model)
        {
            var dto = model as AddressDTO; 
            return new AddressModel()
            {
                Id = dto!.Id,
                ExistAddress = dto.ExistAddress
            };
        }

        public static AddressDTO ToDto(AddressModel entity)
        {

            return new AddressDTO()
            {
                Id = entity.Id,
                ExistAddress = entity.ExistAddress
            };
        }
    }
}