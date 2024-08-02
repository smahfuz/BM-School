using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;
using SERVICE.IServices;
using SERVICE.Services;
using System.CodeDom;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassLevelService _classLevelService;
        public StudentController(IStudentService studentService,
            IClassLevelService classLevelService)
        {
            _studentService = studentService;
            _classLevelService = classLevelService;
        }

        public async Task<IActionResult> Index()
        {
            
            var obj = await _studentService.GetAllAsync();
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var obj = new StudentView();
            
            obj.ClassList = _classLevelService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentView studentView)
        {
            if(ModelState.IsValid)
            {
                var obj = new Student();
                obj.Name = studentView.Name;
                obj.Phone = studentView.Phone;
                obj.ClassId = studentView.ClassId;

                await _studentService.InsertAsync(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View(null);
            }
        }
    }
}
