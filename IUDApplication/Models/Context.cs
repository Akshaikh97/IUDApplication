using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
