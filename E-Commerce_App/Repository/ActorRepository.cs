using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace E_Commerce_App.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext context;

        public ActorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            await context.Actors.AddAsync(actor);
            context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Actor actor = await GetByIdAsync(id);
            context.Actors.Remove(actor);
            context.SaveChanges() ;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await context.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(int id, Actor newActor)
        {
            Actor oldActor = await GetByIdAsync(id);
            oldActor.ProfilePictureURL = newActor.ProfilePictureURL;
            oldActor.FullName = newActor.FullName;
            oldActor.Bio = newActor.Bio;
            context.SaveChanges();
        }
    }
}
