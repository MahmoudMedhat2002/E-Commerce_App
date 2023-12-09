using E_Commerce_App.Models;
using System.Linq.Expressions;

namespace E_Commerce_App.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class , IEntityBase , new()
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(params Expression<Func<T , object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T actor);

        Task UpdateAsync(int id, T newActor);

        Task DeleteAsync(int id);
    }
}
