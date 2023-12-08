using E_Commerce_App.Data.Base;

namespace E_Commerce_App.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
