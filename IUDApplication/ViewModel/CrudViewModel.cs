using IUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.ViewModel
{
    public class CrudViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public Product Product { get; set; }

        public List<Product> ProductList { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
