using CORE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_School.ViewModel
{
    public class StudentView
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? SubjectName { get; set; }
        public String? Phone { get; set; }
        public int Mark {  get; set; }
        public string? Grade { get; set; }
        public int CourseId { get; set; }
        public string? ClassLevel { get; set; }

        [Required]
        public int ClassId { get; set; }
        public List<SelectListItem>?  ClassList { get; set; }
        public List<SelectListItem>?  Courses { get; set; }

        


    }
}
