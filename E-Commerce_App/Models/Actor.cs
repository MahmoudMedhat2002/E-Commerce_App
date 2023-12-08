using E_Commerce_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }
        [StringLength(50 , MinimumLength = 3 , ErrorMessage = "The Name should be between 3 and 50")]
        public string FullName { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "The Name should be between 3 and 50")]
        public string Bio { get; set; }

        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
