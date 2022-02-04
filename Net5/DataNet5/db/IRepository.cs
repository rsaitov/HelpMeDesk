using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Add(T entity);
        T Update(T entity);

        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
