namespace BLL.Interfaces;

public interface IService<M>
    where M : IModel
{
    public List<M> GetAll();
    M? Get(int id);
    public List<M> Find(Func<M, bool> predicate);
    public void Create(M dto);
    public void Update(M dto);
    public void Delete(int id);
}