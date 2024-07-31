using System.ComponentModel.DataAnnotations;

namespace Web_School.ViewModel
{
    public class DesignationView
    {
        [Required]
        [Display(Name = "Teacher Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Teacher Level")]
        public string Description { get; set; }
    }
}
