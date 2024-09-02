using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SERVICE.IServices;
using SERVICE.Services;
using System;
using System.Collections.Immutable;
using System.Security.Cryptography;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class ResultController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IResultService _resultService;
        

        public ResultController(IStudentService studentService,
            IClassLevelService classLevelService,
            ICourseService courseService,
            IResultService resultService
            )
        {
            _resultService = resultService;
            _courseService = courseService;
            _studentService = studentService;
            _classLevelService = classLevelService;
        }
        public async Task<IActionResult> Index()
        {

            var obj = await _resultService.GetAllAsync();
            return View(obj);
        }

        public async Task<IActionResult> ClassErStudent()
        {
            var obj1 = new ClassStudent();
            obj1.Classes = _classLevelService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(obj1);
        }
        [Produces("application/json")]
        public async Task<IActionResult> GetStudent(int did)
        {
            var obj = await _studentService.GetStudentByClassIdAsync(did);
            return Json(obj);
        }
        public async Task<IActionResult> ClassErSubject()
        {
            var obj1 = new ClassStudent();
            obj1.Classes = _classLevelService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(obj1);
        }
        [Produces("application/json")]
        public async Task<IActionResult> GetSubject(int did)
        {
            var obj = await _courseService.GetCourseByClassIdAsync(did); 
            return Json(obj);
        }

        public async Task<IActionResult> GetClassStudents(int id,int subId)
        {
            var obj = await _studentService.GetStudentByClassIdAsync(id);
            ClassLevel classLevel = await _classLevelService.GetIdAsync(id);           
            Course course = await _courseService.GetIdAsync(subId);

            var stuv = new List<StudentView>();
            for (int i = 0; i < obj.Count; i++)
            {
                var stu = new StudentView();
                stu.Name = obj[i].Name;
                stu.SubjectName = course.Name;
                stu.ClassLevel = classLevel.Name;
                stu.ClassId = id;
                stu.CourseId = subId;
                stu.StudentId = obj[i].Id;
                stuv.Add(stu);

            }
            if (obj != null)
            {
                return PartialView("_GetClassStudents", stuv);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]       
        public async Task<IActionResult> GetMarks(List<StudentView> studentViews)
        {
            //Student stu = await _studentService.GetIdAsync(id);
            //var obj = await _studentService.GetStudentByClassIdAsync(studentViews.);
            //ClassLevel classLevel = await _classLevelService.GetIdAsync(studentViews.);
            //Course course = await _courseService.GetIdAsync(subId);

            var resv = new List<ResultSheet>();

            foreach (var studentView in studentViews)
            {
                var obj = new ResultSheet();
                

                obj.ClassId = studentView.ClassId;
                obj.CourseId = studentView.CourseId;
                obj.StudentId = studentView.StudentId;
                obj.Mark = studentView.Mark;
                

                if (obj.Mark >= 80 && obj.Mark <= 100)
                {
                    obj.Grade = "A+";
                }
                else if (obj.Mark >= 70)
                {
                    obj.Grade = "A";
                }
                else if (obj.Mark >= 60)
                {
                    obj.Grade = "A-";
                }
                else if (obj.Mark >= 50)
                {
                    obj.Grade = "B";
                }
                else if (obj.Mark >= 33)
                {
                    obj.Grade = "C";
                }
                else
                {
                    obj.Grade = "F";
                }




                await _resultService.InsertAsync(obj);


            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ClassResultIndex()
        {
            var obj1 = new ClassStudent();
            obj1.Classes = _classLevelService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(obj1);

            
        }

        




    }
}
