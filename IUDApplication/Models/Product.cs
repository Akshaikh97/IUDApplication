using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

    }
}
