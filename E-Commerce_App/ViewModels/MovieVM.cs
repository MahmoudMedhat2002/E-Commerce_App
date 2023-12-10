using E_Commerce_App.Data.Base;
using E_Commerce_App.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class MovieVM 
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Movie description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Movie poster URL")]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Movie start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Movie end date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        [Required]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

        [Required]
        [Display(Name = "Select a Cinema")]
        public int CinemaId { get; set; }

        [Required]
        [Display(Name = "Select a Producer")]
        public int ProducerId { get; set; }
        

    }
}
