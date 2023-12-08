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
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Actor actor)
        {
            if(ModelState.IsValid)
            {
                ActorRepository.Add(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        public IActionResult Details(int id)
        {
            Actor actor = ActorRepository.GetById(id);
            if(actor != null)
            {
                return View(actor);
            }
            return View("NotFound");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Actor actor = ActorRepository.GetById(id);
            if (actor != null)
            {
                return View(actor);
            }
            return View("NotFound");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , Actor newactor)
        {
            if(ModelState.IsValid)
            {
                ActorRepository.update(id,newactor);
                return RedirectToAction("Index");
            }
            return View(newactor);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Actor actor = ActorRepository.GetById(id);
            if (actor != null)
            {
                return View("Delete", actor);
            }
            return View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id , Actor delactor)
        {
            Actor actor = ActorRepository.GetById(id);
            if(actor != null)
            {
                ActorRepository.delete(id);
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
        
    }
}
