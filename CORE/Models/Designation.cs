using CORE.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Designation : BaseEntity
    {
        [Display(Name = "Teacher Title")]
        public string? Title { get; set; }
        [Display(Name = "Teacher Level")]
        public string? Description { get; set; }
        public List<Teacher>? Teachers { get; set; }
    }
}
