using E_Commerce_App.Models;
using E_Commerce_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaRepository CinemaRepository;

        public CinemasController(ICinemaRepository CinemaRepository)
        {
            this.CinemaRepository = CinemaRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await CinemaRepository.GetAllAsync();
            return View(allCinemas);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> New(Cinema cinema)
        {
            if(ModelState.IsValid)
            {
                await CinemaRepository.AddAsync(cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);
        }



    }
}
