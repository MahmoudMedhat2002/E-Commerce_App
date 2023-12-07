using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public interface IActorRepository
    {
        List<Actor> GetAll();

        Actor GetById(int id);

        void Add(Actor actor);

        void update(int id , Actor newActor);

        void delete(int id);
    }
}
