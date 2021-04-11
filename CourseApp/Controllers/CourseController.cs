using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {

        private ICourseRepository _repo;

        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        [TempData]
        public string Message { get; set; }

        public IActionResult Index()
        {
            var courses = _repo.GetCourses();
            var count = courses.Count();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Edit(int courseId)
        {
            ViewBag.ActionMode = "Edit";
            return View(_repo.GetById(courseId));
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {       
               
                _repo.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
        
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View(nameof(Edit), new Course());
        }

        [HttpPost]
        public IActionResult Create(Course newCourse)
        {

           _repo.CreateCourse(newCourse);
      
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Delete(int courseSlug)
        {
            _repo.DeleteCourse(courseSlug);
            TempData["Message"] = "Course is deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}