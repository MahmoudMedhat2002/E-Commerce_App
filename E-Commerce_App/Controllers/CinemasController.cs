using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext context;

        public CinemasController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await context.Cinemas.ToListAsync();
            return View();
        }
    }
}
