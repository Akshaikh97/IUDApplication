using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
