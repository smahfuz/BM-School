using CORE.Models;
using System.ComponentModel.DataAnnotations;

namespace Web_School.ViewModel
{
    public class ClassLevelView
    {

        [Required]
        [Display(Name = "Class Name")]
        public String  Name { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int  RoomNumber { get; set; }
    }
}
