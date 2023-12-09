using E_Commerce_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        [StringLength(50, MinimumLength = 2 , ErrorMessage = "Cinema Name must be in range 2 and 50" )]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Description must be in range 2 and 50")]
        public string Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
