using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICE.IServices;
using SERVICE.Services;
using Web_School.ViewModel;

namespace Web_School.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
            
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesignationView designationView)
        {
            var obj = new Designation();

            obj.Title = designationView.Title;
            obj.Description = designationView.Description;
            
            await _designationService.InsertAsync(obj);
            return RedirectToAction("Index");
        }
    }
}
