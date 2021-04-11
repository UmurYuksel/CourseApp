using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using CourseApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepostiory _repository;
        private ICourseRepository _courseRepository;

        public InstructorController(IInstructorRepostiory repostiory, ICourseRepository courseRepository)
        {
            _repository = repostiory;
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            ViewBag.InstructorEditId = TempData["InstructorEditId"];
            ViewBag.InstructorCreateId = TempData["InstructorCreateId"];
            ViewBag.InstructorChangeId = TempData["InstructorChangeId"];
            return View(_repository.GetAll());
          
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            TempData["InstructorEditId"] = Id;
             return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Instructor entity)
        {
            _repository.Update(entity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            TempData["InstructorCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Change(int id)
        {
            TempData["InstructorChangeId"] = id;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Change(int Id,Course[] courses)
        {

            _courseRepository.UpdateAll(Id, courses);
            return RedirectToAction(nameof(Index));
        }

       


    }
}