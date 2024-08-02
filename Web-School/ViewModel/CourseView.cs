using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_School.ViewModel
{
    public class CourseView
    {
        public string Name { get; set; }
        public string Code { get; set; }
        [Required] 
        public int ClassId { get; set; }
        public List<SelectListItem>? ClassList { get; set; }

    }
}
