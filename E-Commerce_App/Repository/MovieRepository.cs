using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;
using E_Commerce_App.ViewModels;
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

        public async Task<MovieDropDownVM> GetMovieDropDownValues()
        {
            var response = new MovieDropDownVM();
            response.Actors = await context.Actors.OrderBy(x => x.FullName).ToListAsync();
            response.Producers = await context.Producers.OrderBy(x => x.FullName).ToListAsync();
            response.Cinemas = await context.Cinemas.OrderBy(x => x.Name).ToListAsync();
            return response;
        }
    }
}
