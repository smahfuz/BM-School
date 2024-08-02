using CORE.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class ClassLevel: BaseEntity
    {
        [Display(Name = "Class Name")]
        public string Name { get; set; }
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        


    }
}
