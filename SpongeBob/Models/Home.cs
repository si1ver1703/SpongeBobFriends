using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Home
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Fill home type")]
        [Display(Name = "Home Type")]
        public string HomeType { get; set; }

        [Required(ErrorMessage = "Invalid")]
        [Display(Name = "isNeighbour")]
        public bool isNeighbour { get; set;}

    }
}
