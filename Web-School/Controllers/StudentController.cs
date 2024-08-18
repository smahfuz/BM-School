﻿using CORE.Models;
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

        public async Task<IActionResult> ClassWiseStudent()
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

        public async Task<IActionResult> GetStudentPartial(int id)
        {
            Student stu = await _studentService.GetIdAsync(id);
            ClassLevel classLevel = await _classLevelService.GetIdAsync(stu.ClassId);

          

            var stuv = new StudentView();
            stuv.Name = stu.Name;
            stuv.Phone = stu.Phone;
            stuv.ClassLevel = classLevel.Name;
            
            
            if (stuv != null)
            {
                return PartialView("_StudentPartial", stuv);
            }
            else
            {
                return null;
            }
        }
    }
}
