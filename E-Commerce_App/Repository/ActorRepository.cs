using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace E_Commerce_App.Repository
{
    public class ActorRepository : EntityBaseRepository<Actor>,IActorRepository
    {
        

        public ActorRepository(AppDbContext context) : base(context)
        {
            
        }

       
    }
}
