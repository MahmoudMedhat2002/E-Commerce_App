using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public interface IActorRepository
    {
       Task<List<Actor>> GetAllAsync();

       Task<Actor> GetByIdAsync(int id);

       Task AddAsync(Actor actor);

       Task UpdateAsync(int id , Actor newActor);

       Task DeleteAsync(int id);
    }
}
