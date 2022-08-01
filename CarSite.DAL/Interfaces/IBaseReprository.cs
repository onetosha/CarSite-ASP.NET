
using CarSite.Domain.Entity;

namespace CarSite.DAL.Interfaces
{
    public interface IBaseReprository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Get(int id);
        Task<List<T>> Select();
        Task<bool> Delete(T entity);
        Task <T> Update(T entity);
    }
}
