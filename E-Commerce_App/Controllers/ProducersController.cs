using E_Commerce_App.Models;
using E_Commerce_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository ProducerRepository;

        public ProducersController(IProducerRepository ProducerRepository)
        {
            this.ProducerRepository = ProducerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await ProducerRepository.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            Producer producer = await ProducerRepository.GetByIdAsync(id);
            if(producer != null)
            {
                return View(producer);
            }
            return View("NotFound");
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Producer producer)
        {
            if (ModelState.IsValid)
            {
                await ProducerRepository.AddAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }
    }
}
