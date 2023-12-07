using E_Commerce_App.Models;
using E_Commerce_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRepository ActorRepository;

        public ActorsController(IActorRepository ActorRepository)
        {
            this.ActorRepository = ActorRepository;
        }

        public IActionResult Index()
        {
            var allActors = ActorRepository.GetAll();
            return View(allActors);
        }
    }
}
