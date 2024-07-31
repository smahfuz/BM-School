using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_School.ViewModel
{
    public class TeacherView
    {
        [Required]
        [Display(Name = "Teacher Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Teacher Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Teacher Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Phone Number")]

        public string Phone { get; set; }
        [Required]
        [Display(Name = "Teacher Sallery")]
        public int Salary { get; set; }
        [Required]
        [Display(Name = "Teacher ADDRESS")]
        public String Address { get; set; }
        [Required]
        public int DesignationId { get; set; }
        [Required]
        public int ClassId { get; set; }
        public List<SelectListItem>? DesignationList { get; set; }
        public List<SelectListItem>? ClassList { get; set; }
    }
}
