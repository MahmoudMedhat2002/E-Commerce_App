using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;
using E_Commerce_App.ViewModels;

namespace E_Commerce_App.Repository
{
    public interface IMovieRepository : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<MovieDropDownVM> GetMovieDropDownValues();
    }
}
