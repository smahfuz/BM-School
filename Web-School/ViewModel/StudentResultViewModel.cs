using CORE.Models;

namespace Web_School.ViewModel
{
    public class StudentResultViewModel
    {
        public string StudentName { get; set; }
        public string Roll {  get; set; }   
        public string ClassName { get; set; }
        public Dictionary<string, int> SubjectMarks { get; set; } // Key: Subject Name, Value: Mark
        public string AverageGrade { get; set; }

        public StudentResultViewModel()
        {
            SubjectMarks = new Dictionary<string, int>();
        }
    }
}
