using System.Collections.Generic;

namespace Bll.Repository
{
    public interface IService
    {
        public List<IModel> GetData();
    }
}