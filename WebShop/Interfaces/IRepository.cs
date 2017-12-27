using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebShop.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
        
        Task<T> Get(long id);
        
        Task<T> Add(T entity);

        Task<long> Delete(long id);
    }
}
