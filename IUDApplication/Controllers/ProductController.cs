using IUDApplication.Models;
using IUDApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Controllers
{
    public class ProductController : Controller
    {
        private Context _db;
        public ProductController(Context db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //List<Product> product = _db.Product.ToList();
            return View(GetProductList(1));
        }
        [HttpPost]
        public IActionResult Index(int CurrentPageIndex)
        {
            return View(GetProductList(CurrentPageIndex));
        }
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

        private CrudViewModel GetProductList(int CurrentPage)
        {
            int MaxRowsPerPage = 5;
            CrudViewModel viewModels = new CrudViewModel();
            viewModels.ProductList = (from Product in _db.Product select Product)//Fetching
                .OrderBy(x => x.Id)//OrderBy-"Id"
                                   //Ex- if "currentPage" is 5
                                   //it will skip first 5 records
                                   //and it will fetch extra 5 recrds based on the page count and the range.
                                   //ex if I'm passing 5, then it will only fatch 5 records.
                .Skip((CurrentPage - 1) * MaxRowsPerPage)
                .Take(MaxRowsPerPage).ToList();
            //Taking the total count of "Product" list from the table.
            //Then I'm deviding by "MaxRowsPerPage".
            //Product.Count/MaxRowsPerPage.
            double PageCount = (double)((decimal)_db.Product.Count() / Convert.ToDecimal(MaxRowsPerPage));
            //I'm pasing "PageCount" value of 'Product' to "viewModels.PageCount".
            viewModels.PageCount = (int)Math.Ceiling(PageCount);
            viewModels.CurrentPageIndex = CurrentPage;
            return viewModels;
        }
    }
}
