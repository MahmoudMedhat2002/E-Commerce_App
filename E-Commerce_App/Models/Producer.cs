namespace E_Commerce_App.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
