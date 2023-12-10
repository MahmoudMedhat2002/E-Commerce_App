using E_Commerce_App.Data.Base;
using E_Commerce_App.Data.Enums;
using E_Commerce_App.Models;
using E_Commerce_App.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace E_Commerce_App.Repository
{
    public class MovieRepository : EntityBaseRepository<Movie> , IMovieRepository
    {
        private readonly AppDbContext context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddMovieAsync(MovieVM movie)
        {
            Movie NewMovie = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                MovieCategory = movie.MovieCategory,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate
            };
            await context.Movies.AddAsync(NewMovie);
            await context.SaveChangesAsync();

            foreach(int actorid in movie.ActorIds)
            {
                var ActorMovie = new Actor_Movie()
                {
                    ActorId = actorid,
                    MovieId = NewMovie.Id
                };
                await context.Actors_Movies.AddAsync(ActorMovie);
            }
            await context.SaveChangesAsync();
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

        public async Task UpdateMovieAsync(MovieVM movie)
        {
            Movie oldMovie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
            oldMovie.Name = movie.Name;
            oldMovie.Description = movie.Description;
            oldMovie.ImageURL = movie.ImageURL;
            oldMovie.MovieCategory = movie.MovieCategory;
            oldMovie.CinemaId = movie.CinemaId;
            oldMovie.ProducerId = movie.ProducerId;
            oldMovie.Price = movie.Price;
            oldMovie.StartDate = movie.StartDate;
            oldMovie.EndDate = movie.EndDate;

            await context.SaveChangesAsync();

            var existingactors = context.Actors_Movies.Where(n => n.MovieId == movie.Id).ToList();
            context.Actors_Movies.RemoveRange(existingactors);
            await context.SaveChangesAsync();



            foreach (int actorid in movie.ActorIds)
            {
                var ActorMovie = new Actor_Movie()
                {
                    ActorId = actorid,
                    MovieId = movie.Id
                };
                await context.Actors_Movies.AddAsync(ActorMovie);
            }
            await context.SaveChangesAsync();
        }
    }
}
