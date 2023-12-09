using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Repository
{
    public class MovieRepository : EntityBaseRepository<Movie> , IMovieRepository
    {
        private readonly AppDbContext context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie = await context.Movies.Include(m => m.Cinema)
                .Include(m => m.Producer).
                Include(m => m.Actors_Movies).
                ThenInclude(am => am.Actor).
                FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }
    }
}
