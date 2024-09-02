using CORE.Models;

namespace Web_School.ViewModel
{
    public class Resultview
    {
        public string StudentName { get; set; }
        public List<Course> Subjects { get; set; }
        public string ClassName { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
    }
}
