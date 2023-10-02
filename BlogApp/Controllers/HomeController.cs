// Controllers/HomeController.cs
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BloggieDbContext _dbContext;

        public HomeController(BloggieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> Catogories = _dbContext.Catogories.ToList();
            return View(Catogories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;

                _dbContext.Catogories.Add(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            Category? category = _dbContext.Catogories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.ModifiedDate = DateTime.Now;

                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category? category = _dbContext.Catogories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult ConfirmDeleteCategory(int id)
        {
            Category? category = _dbContext.Catogories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Catogories.Remove(category);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
