using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class SpongeBobFriends
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Fill the form")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Fill the form")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill the form")]
        [Display(Name = "Job")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Fill Gender")]
        [Display(Name = "JobPlace")]
        public string JobPlace { get; set; }

        [Required(ErrorMessage = "Fill Year Of Birth")]
        [Display(Name = "SkinCollor")]
        public string SkinCollor { get; set; }

        [ForeignKey("Parent")]
        public Home home_id { get; set; }

    }
}
