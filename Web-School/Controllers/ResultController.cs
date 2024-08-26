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
        

        public ResultController(IStudentService studentService,
            IClassLevelService classLevelService)
        {
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
    }
}
