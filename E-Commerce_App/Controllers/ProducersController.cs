using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class ProducersController : Controller
    {

        private readonly AppDbContext context;

        public ProducersController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await context.Producers.ToListAsync();
            return View();
        }
    }
}
