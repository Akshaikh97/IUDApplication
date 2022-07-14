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

        //public List<Product> ProductList { get; set; }
        //public int CurrentPageIndex { get; set; }
        //public int PageCount { get; set; }
        //public int TotalItems { get; private set; }//total no of rec
        //public int CurrentPage { get; private set; }//active page of the pager-bar
        //public int PageSize { get; private set; }//
        //public int TotalPages { get; private set; }
        //public int StartPage { get; private set; }
        //public int EndPage { get; private set; }
        ////now need to setr values 
        //public CrudViewModel()
        //{

        //}

    }
}
