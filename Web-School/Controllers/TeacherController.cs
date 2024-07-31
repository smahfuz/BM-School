using Microsoft.AspNetCore.Mvc;

namespace Web_School.Controllers
{
    public class TeacherController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
