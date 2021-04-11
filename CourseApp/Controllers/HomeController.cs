using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using CourseApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private CourseContext _db;

        public HomeController(CourseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            model.RequestSlug = model.Name.ToUpper()+"-"+ HelperMethods.CreateRandomSlug();
            _db.Requests.Add(model);
            _db.SaveChanges();
            return View("Thanks",model);
        }

        public IEnumerable<Request> Details()
        {

            return _db.Requests;
        }

       
    }
}