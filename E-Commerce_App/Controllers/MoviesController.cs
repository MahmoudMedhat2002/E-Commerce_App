﻿using E_Commerce_App.Models;
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

        public async Task<IActionResult> Details(int id)
        {
            Movie movie = await MovieRepository.GetMovieByIdAsync(id);
            if(movie != null)
            {
                return View(movie);
            }
            return View("Not Found");
        }

        public async Task<IActionResult> New()
        {
            var movieLists = await MovieRepository.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieLists.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieLists.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieLists.Actors, "Id", "FullName");
            return View();
        }
    }
}
