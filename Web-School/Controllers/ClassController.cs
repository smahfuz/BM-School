using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SERVICE.IServices;
using SERVICE.Services;
using System;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly IStudentService _studentService;
        private readonly IResultService _resultService;
        private readonly ICourseService _courseService;
        public ClassController(
            IClassLevelService classLevelService, 
            IResultService resultService, ICourseService courseService,
            IStudentService studentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _classLevelService = classLevelService;
            _resultService = resultService;
        }


        public async Task<IActionResult> Index()
        {
            var obj = await _classLevelService.GetAllAsync();
            return View(obj);

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClassLevelView classLevelview)
        {
            var obj = new ClassLevel();

            obj.Name = classLevelview.Name;
            obj.RoomNumber = classLevelview.RoomNumber;
            await _classLevelService.InsertAsync(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<JsonResult> GetClassList()
        {
            var classes = await _classLevelService.GetAllAsync();
            return new JsonResult(classes);
        }

        public async Task<IActionResult> GetStudentResults(int classId)
        {
            var studentResults = new List<StudentResultViewModel>();

            var students = await _studentService.GetStudentByClassIdAsync(classId);
            ClassLevel classLevel = await _classLevelService.GetIdAsync(classId);

            if (students == null || !students.Any())
            {
                throw new Exception($"No students found for Class ID: {classId}");
            }

            foreach (var student in students)
            {
                var resultViewModel = new StudentResultViewModel
                {
                    StudentName = student.Name,
                    ClassName = classLevel.Name,
                    Roll = student.Roll,
                    SubjectMarks = new Dictionary<string, int>()
                };

                var results = await _resultService.GetResultsByStudentIdAsync(student.Id);

                foreach (var result in results)
                {
                    if (result.Course != null)
                    {
                        // Use TryAdd or check and update approach to avoid duplicate keys
                        if (!resultViewModel.SubjectMarks.TryAdd(result.Course.Name, result.Mark))
                        {
                            // Optionally handle the case where the key already exists
                            resultViewModel.SubjectMarks[result.Course.Name] = result.Mark;
                        }
                    }
                }

                resultViewModel.AverageGrade = CalculateAverageGrade(results.Select(r => r.Grade).ToList());
                studentResults.Add(resultViewModel);
            }

            return View(studentResults);
        }



        private string CalculateAverageGrade(List<string> grades)
        {
            // Dictionary to map grades to numerical values
            var gradeValues = new Dictionary<string, double>
    {
        { "A+", 5.0 },
        { "A", 4.0 },
        { "A-", 3.0 },
        { "B", 2.5 },
        { "C", 2.0 }
    };

            double sum = 0;
            int count = grades.Count;

            // Check if grades list is empty
            if (count == 0)
            {
                return "F"; // Return F if no grades are provided
            }

            // Calculate the sum of numerical values
            foreach (var grade in grades)
            {
                if (gradeValues.TryGetValue(grade, out double value))
                {
                    sum += value;
                }
                else
                {
                    // Handle unexpected grade values if necessary
                    // For this example, we'll treat unexpected grades as 0
                    sum += 0;
                }
            }

            // Calculate average
            double average = sum / count;

            // Determine the letter grade based on the average
            if (average >= 5)
            {
                return "A+";
            }
            else if (average >= 4)
            {
                return "A";
            }
            else if (average >= 3)
            {
                return "A-";
            }
            else if (average >= 2.5)
            {
                return "B";
            }
            else if (average >= 2)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }

    }
}
