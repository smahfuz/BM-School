using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using REPO.IRepositories;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IClasslevelRepository _classlevelRepository;
        public CourseController(ICourseRepository courseRepository, 
            IClasslevelRepository classlevelRepository)
        {
            _courseRepository = courseRepository;
            _classlevelRepository = classlevelRepository;
        }
        public async Task<IActionResult> Index()
        {
            var obj = await _courseRepository.GetAllAsync();
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var obj = new CourseView();
            obj.ClassList = _classlevelRepository.GetAllAsync().Result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            return View(obj);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseView courseView)
        {
            if (ModelState.IsValid)
            {
                var obj = new Course();
                obj.Name = courseView.Name;
                obj.Code = courseView.Code;
                obj.ClassId = courseView.ClassId;

                await _courseRepository.InsertAsync(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View(null);
            }
            
        }
    }
}
