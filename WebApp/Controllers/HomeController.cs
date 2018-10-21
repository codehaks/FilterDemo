using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [NoEdge]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Error()
        {
            return View();
        }

        [NoEdge]
        //[TypeFilter(typeof(ShowErrorPageAttribute))]
        [ShowErrorPageType]
        public IActionResult Index()
        {
            //throw new Exception("Something went wrong !");
            var model = _db.Movies;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateModel]
        public IActionResult Create(Movie model)
        {
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [TypeFilter(typeof(ViewCountAttribute))]
        public IActionResult Details(int id)
        {
            var model = _db.Movies.SingleOrDefault(m => m.Id == id);
            return View(model);
        }
    }
}