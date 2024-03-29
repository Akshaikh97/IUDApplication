﻿using IUDApplication.Models;
using IUDApplication.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ClosedXML.Excel;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _db;
        public ProductController(Context db)
        {
            _db = db;
        }
        public IActionResult Index(int PageNo = 1, bool a = true)
        {
            List<Product> product = _db.Product.Include(x => x.Category)
                                               .Where(c => c.Category.ActiveOrNot
                                               .Equals(a)).ToList();
            var p = _db.Product.Where(x => x.Category.ActiveOrNot == a).Select(x => x.Category).ToList();
            int NoOfRecordsPerPage = 3;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(product.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            product = product.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(product);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Insert()
        {
            List<Category> Category = _db.Category.ToList();
            CrudViewModel viewModel = new CrudViewModel
            {
                Category = Category
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Insert(CrudViewModel crudViewModel)
        {
            _db.Product.Add(crudViewModel.Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            Product product = _db.Product.SingleOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return RedirectToAction("Update");
            }
            List<Category> category = _db.Category.ToList();
            CrudViewModel crudViewModel = new CrudViewModel
            {
                Product = product,
                Category = category
            };
            return View(crudViewModel);
        }
        [HttpPost]
        public IActionResult Update(CrudViewModel crudViewModel)
        {
            Product product = _db.Product.SingleOrDefault(x => x.Id == crudViewModel.Product.Id);
            product.ProductName = crudViewModel.Product.ProductName;
            product.CategoryId = crudViewModel.Product.CategoryId;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            Product product = _db.Product.SingleOrDefault(x => x.Id == Id);
            _db.Product.Remove(product);
            _db.SaveChanges();
            return View();
        }
        public IActionResult ExportContentToExcel()
        {

            var products = _db.Product.Include(x => x.Category);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Products");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "ProductName";
                worksheet.Cell(currentRow, 3).Value = "Category";
                foreach (var product in products)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = product.Id;
                    worksheet.Cell(currentRow, 2).Value = product.ProductName;
                    worksheet.Cell(currentRow, 3).Value = product.Category.CategoryName;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Products.xlsx");
                }
            }
        }




    }
}
