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

        public async Task<IActionResult> Index()
        {
            var allActors = await ActorRepository.GetAllAsync();
            return View(allActors);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Actor actor)
        {
            if(ModelState.IsValid)
            {
                await ActorRepository.AddAsync(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        public async Task<IActionResult> Details(int id)
        {
            Actor actor = await ActorRepository.GetByIdAsync(id);
            if(actor != null)
            {
                return View(actor);
            }
            return View("NotFound");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Actor actor = await ActorRepository.GetByIdAsync(id);
            if (actor != null)
            {
                return View(actor);
            }
            return View("NotFound");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Actor newactor)
        {
            if(ModelState.IsValid)
            {
               await ActorRepository.UpdateAsync(id,newactor);
                return RedirectToAction("Index");
            }
            return View(newactor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Actor actor = await ActorRepository.GetByIdAsync(id);
            if (actor != null)
            {
                return View("Delete", actor);
            }
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id , Actor delactor)
        {
            Actor actor = await ActorRepository.GetByIdAsync(id);
            if(actor != null)
            {
                await ActorRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
        
    }
}
