using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public interface IMovieRepository : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
