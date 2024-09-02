using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_School.ViewModel
{
    public class ResultSheetView
    {
        public int Mark { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public List<SelectListItem>? ClassList { get; set; }
        public List<SelectListItem>? Courses { get; set; }
    }
}
