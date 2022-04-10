using DAL.Interfaces;

namespace BLL.Interfaces;

public interface IMapper<E, M>
    where E : IEntity
    where M : IModel
{
    public E FromDto(M dto);
    public M ToDto(E entity);
}