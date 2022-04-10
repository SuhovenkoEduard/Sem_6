using BLL.DTO;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class RestaurantService : IService<RestaurantDTO>
{
    private readonly IMapper<Restaurant, RestaurantDTO> _mapper;
    private readonly IRepository<Restaurant> _repository;

    public RestaurantService(IRepository<Restaurant> pizzaRepository)
    {
        _repository = pizzaRepository;
        _mapper = new RestaurantMapper();
    }

    public List<RestaurantDTO> GetAll()
    {
        return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
    }

    public RestaurantDTO? Get(int id)
    {
        var entity = _repository.Get(id);
        return entity == null ? null : _mapper.ToDto(entity);
    }

    public void Create(RestaurantDTO dto)
    {
        _repository.Create(_mapper.FromDto(dto));
        _repository.Save();
    }

    public void Update(RestaurantDTO dto)
    {
        var entity = _mapper.FromDto(dto);
        _repository.Update(entity);
        _repository.Save();
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _repository.Save();
    }

    public List<RestaurantDTO> Find(Func<RestaurantDTO, bool> predicate)
    {
        return _repository
            .Find(entity => predicate(_mapper.ToDto(entity)))
            .Select(entity => _mapper.ToDto(entity))
            .ToList();
    }
}