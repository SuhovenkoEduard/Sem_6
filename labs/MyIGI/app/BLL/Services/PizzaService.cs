using BLL.DTO;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class PizzaService : IService<PizzaDTO>
{
    private readonly IMapper<Pizza, PizzaDTO> _mapper;
    private readonly IRepository<Pizza> _repository;

    public PizzaService(IRepository<Pizza> pizzaRepository)
    {
        _repository = pizzaRepository;
        _mapper = new PizzaMapper();
    }

    public List<PizzaDTO> GetAll()
    {
        return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
    }

    public PizzaDTO? Get(int id)
    {
        var entity = _repository.Get(id);
        return entity == null ? null : _mapper.ToDto(entity);
    }

    public void Create(PizzaDTO dto)
    {
        _repository.Create(_mapper.FromDto(dto));
        _repository.Save();
    }

    public void Update(PizzaDTO dto)
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

    public List<PizzaDTO> Find(Func<PizzaDTO, bool> predicate)
    {
        return _repository
            .Find(entity => predicate(_mapper.ToDto(entity)))
            .Select(entity => _mapper.ToDto(entity))
            .ToList();
    }
}