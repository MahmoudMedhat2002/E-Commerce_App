using E_Commerce_App.Data.Base;
using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
    public class ProducerRepository:EntityBaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(AppDbContext context):base(context) 
        {
            
        }
    }
}
