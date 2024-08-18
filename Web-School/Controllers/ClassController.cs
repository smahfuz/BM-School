using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SERVICE.IServices;
using SERVICE.Services;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassLevelService _classLevelService;
        private readonly IStudentService _studentService;
        public ClassController(IClassLevelService classLevelService)
        {
            _classLevelService = classLevelService;
            
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

        


    }
}
