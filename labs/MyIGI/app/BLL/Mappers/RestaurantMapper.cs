using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Mappers;

public class RestaurantMapper : IMapper<Restaurant, RestaurantDTO>
{
    public Restaurant FromDto(RestaurantDTO dto)
    {
        return new()
        {
            Id = dto.Id,
            Address = dto.Address,
            Revenue = dto.Revenue
        };
    }

    public RestaurantDTO ToDto(Restaurant entity)
    {
        return new()
        {
            Id = entity.Id,
            Address = entity.Address,
            Revenue = entity.Revenue
        };
    }
}