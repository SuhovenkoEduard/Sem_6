using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Mappers;

public class CookMapper : IMapper<Cook, CookDTO>
{
    public Cook FromDto(CookDTO dto)
    {
        return new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Age = dto.Age,
            PizzaId = dto.PizzaId,
            RestaurantId = dto.RestaurantId
        };
    }

    public CookDTO ToDto(Cook entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Age = entity.Age,
            PizzaId = entity.PizzaId,
            RestaurantId = entity.RestaurantId
        };
    }
}