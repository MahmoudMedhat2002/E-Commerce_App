using E_Commerce_App.Models;
using E_Commerce_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository MovieRepository;

        public MoviesController(IMovieRepository MovieRepository)
        {
            this.MovieRepository = MovieRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await MovieRepository.GetAllAsync(m => m.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await MovieRepository.GetAllAsync(m => m.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filtered = allMovies.Where(m => m.Name.Contains(searchString) || m.Description.Contains(searchString)).ToList();
                return View("Index" , filtered);
            }
            return View("Index", allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            Movie movie = await MovieRepository.GetMovieByIdAsync(id);
            if(movie != null)
            {
                return View(movie);
            }
            return View("Not Found");
        }
        [HttpGet]
        public async Task<IActionResult> New()
        {
            var movieLists = await MovieRepository.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieLists.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieLists.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieLists.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(MovieVM movie)
        {
            if (ModelState.IsValid)
            {
                await MovieRepository.AddMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Movie movieData = await MovieRepository.GetMovieByIdAsync(id);

            if (movieData == null) return View("NotFound");

            var movieVM = new MovieVM()
            {
                Id = movieData.Id,
                Name = movieData.Name,
                Description = movieData.Description,
                ImageURL = movieData.ImageURL,
                MovieCategory = movieData.MovieCategory,
                CinemaId = movieData.CinemaId,
                ProducerId = movieData.ProducerId,
                Price = movieData.Price,
                StartDate = movieData.StartDate,
                EndDate = movieData.EndDate,
                ActorIds = movieData.Actors_Movies.Select(am => am.ActorId).ToList(),
                
            };

            var movieLists = await MovieRepository.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieLists.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieLists.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieLists.Actors, "Id", "FullName");

            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , MovieVM movie)
        {
            if (ModelState.IsValid)
            {
                await MovieRepository.UpdateMovieAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
