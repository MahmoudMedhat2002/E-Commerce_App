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
    }
}
