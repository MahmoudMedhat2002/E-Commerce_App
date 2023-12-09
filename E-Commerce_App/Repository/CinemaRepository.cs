using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public class CinemaRepository : EntityBaseRepository<Cinema> , ICinemaRepository
    {
        public CinemaRepository(AppDbContext context): base(context)
        {
            
        }
    }
}
