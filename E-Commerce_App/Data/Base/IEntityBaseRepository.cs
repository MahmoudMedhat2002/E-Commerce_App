using E_Commerce_App.Models;

namespace E_Commerce_App.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class , IEntityBase , new()
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T actor);

        Task UpdateAsync(int id, T newActor);

        Task DeleteAsync(int id);
    }
}
