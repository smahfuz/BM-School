using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using REPO.IRepositories;
using SERVICE.IServices;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherService _teacherService;
        private readonly IDesignationService _designationService;
        private readonly IClassLevelService _classLevelService;

        public TeacherController(
            ITeacherService teacherService,
            IDesignationService designationService,
            IClassLevelService classLevelService
            )
        {
            _teacherService = teacherService;
            _classLevelService = classLevelService;
            _designationService = designationService;
            
        }

        public async Task<IActionResult> Index()
        {

            var ob = await _teacherService.GetAllAsync();
            return View(ob);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teacher = new TeacherView();
            teacher.DesignationList = _designationService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title,

            }).ToList();
            teacher.ClassList = _classLevelService.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value= x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherView teacherView)
        {
            if (ModelState.IsValid)
            {
                var obj = new Teacher();
                obj.Name = teacherView.Name;
                obj.Address = teacherView.Address;
                obj.Email = teacherView.Email;
                obj.Phone = teacherView.Phone;
                obj.Salary = teacherView.Salary;
                obj.ClassId = teacherView.ClassId;
                obj.DesignationId = teacherView.DesignationId;
                obj.Password = teacherView.Password;
                

                await _teacherService.InsertAsync(obj);
                return RedirectToAction("Index");
            }

            else
            {
                return View(null);
            }

        }




    }
}
