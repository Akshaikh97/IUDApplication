﻿using IUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _db;
        public CategoryController(Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> category = _db.Category.ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            Category category = _db.Category.SingleOrDefault(x => x.CategoryId == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category _category)
        {
            Category category = _db.Category.SingleOrDefault(x => x.CategoryId == _category.CategoryId);
            category.CategoryName = _category.CategoryName;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            Category exsistingCategory = _db.Category.SingleOrDefault(x => x.CategoryId == Id);
           
            return View(exsistingCategory);
        }
        [HttpPost]
        public IActionResult Delete(Category category,int Id)
        {
           Category exsistingCategory = _db.Category.SingleOrDefault(x => x.CategoryId == Id);
            _db.Category.Remove(exsistingCategory);
            _db.SaveChanges();
            return RedirectToAction("Index","Category");
        }

        public IActionResult Active(Category _category)
        {
            Category category = _db.Category.SingleOrDefault(x => x.CategoryId == _category.CategoryId);
            category.ActiveOrNot = true;
            _db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Deactive(Category _category)
        {
            Category category = _db.Category.SingleOrDefault(x => x.CategoryId == _category.CategoryId);
            category.ActiveOrNot = false;
            _db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
