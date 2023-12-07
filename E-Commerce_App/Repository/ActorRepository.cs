using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext context;

        public ActorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Actor actor = context.Actors.FirstOrDefault(a => a.Id == id);
            context.Actors.Remove(actor);
            context.SaveChanges() ;
        }

        public List<Actor> GetAll()
        {
            return context.Actors.ToList();
        }

        public Actor GetById(int id)
        {
            return context.Actors.FirstOrDefault(a => a.Id == id);
        }

        public void update(int id, Actor newActor)
        {
            Actor oldActor = context.Actors.FirstOrDefault(a => a.Id == id);
            oldActor.ProfilePictureURL = newActor.ProfilePictureURL;
            oldActor.FullName = newActor.FullName;
            oldActor.Bio = newActor.Bio;
            context.SaveChanges();
        }
    }
}
