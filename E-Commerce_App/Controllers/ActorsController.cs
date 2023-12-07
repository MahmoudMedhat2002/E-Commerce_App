using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.Actors.ToListAsync();
            return View();
        }
    }
}
