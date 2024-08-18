using CORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_School.ViewModel
{
    public class StudentView
    {
        public string Name { get; set; }
        public String Phone { get; set; }

        [Required]
        public int ClassId { get; set; }
        public List<SelectListItem>?  ClassList { get; set; }

        public string? ClassLevel { get; set; }


    }
}
