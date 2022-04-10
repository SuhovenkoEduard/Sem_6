using BLL.DTO;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class CookService : IService<CookDTO>
{
    private readonly IMapper<Cook, CookDTO> _mapper;
    private readonly IRepository<Cook> _repository;

    public CookService(IRepository<Cook> pizzaRepository)
    {
        _repository = pizzaRepository;
        _mapper = new CookMapper();
    }

    public List<CookDTO> GetAll()
    {
        return _repository.GetAll().Select(entity => _mapper.ToDto(entity)).ToList();
    }

    public CookDTO? Get(int id)
    {
        var entity = _repository.Get(id);
        return entity == null ? null : _mapper.ToDto(entity);
    }

    public void Create(CookDTO dto)
    {
        _repository.Create(_mapper.FromDto(dto));
        _repository.Save();
    }

    public void Update(CookDTO dto)
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

    public List<CookDTO> Find(Func<CookDTO, bool> predicate)
    {
        return _repository
            .Find(entity => predicate(_mapper.ToDto(entity)))
            .Select(entity => _mapper.ToDto(entity))
            .ToList();
    }
}