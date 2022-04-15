using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var user = db.User.Select(s=>s).ToList();
            
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(TableModel tableModel)
        {
            db.User.Add(tableModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
