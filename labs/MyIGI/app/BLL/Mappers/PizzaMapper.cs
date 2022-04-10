using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Mappers;

public class PizzaMapper : IMapper<Pizza, PizzaDTO>
{
    public Pizza FromDto(PizzaDTO dto)
    {
        return new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Caloric = dto.Caloric
        };
    }

    public PizzaDTO ToDto(Pizza entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Caloric = entity.Caloric
        };
    }
}