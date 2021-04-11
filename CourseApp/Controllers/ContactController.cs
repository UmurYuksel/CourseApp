using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Data.Abstract;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class ContactController : Controller
    {
        IGenericRepository<Contact> _repo;

        public ContactController(IGenericRepository<Contact> repo) => _repo = repo;


        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
    }
}