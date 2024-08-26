using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SERVICE.IServices;
using SERVICE.Services;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class ResultController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        

        public ResultController(IStudentService studentService,
            IClassLevelService classLevelService,
            ICourseService courseService
            )
        {
            _courseService = courseService;
            _studentService = studentService;
            _classLevelService = classLevelService;
        }
        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> GetClassStudents(int id)
        {
            var obj = await _studentService.GetStudentByClassIdAsync(id);

            var obj1 = new List<StudentView>();
            for (int i = 0; i < obj.Count; i++)
            {
                var stu = new StudentView();
                stu.Name = obj[i].Name;
                obj1.Add(stu);

            }
            if (obj != null)
            {
                return PartialView("_GetClassStudents", obj1);
            }
            else
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<IActionResult> GetSubjectMark(List<StudentView> studentViews)
        {
            return View();
        }
    }
}
