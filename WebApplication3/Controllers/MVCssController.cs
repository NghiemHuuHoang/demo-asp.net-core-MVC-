using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MVCssController : Controller
    {
        private readonly Db _db;
        public MVCssController(Db db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.MVCs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MVC mVC)
        {
            if (ModelState.IsValid)
            {
                _db.Add(mVC);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mVC);
        }
        
    }
}