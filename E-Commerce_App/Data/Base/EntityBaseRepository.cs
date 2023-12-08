using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_Commerce_App.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityentry = context.Entry<T>(entity);
            entityentry.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityentry = context.Entry<T>(entity);
            entityentry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
