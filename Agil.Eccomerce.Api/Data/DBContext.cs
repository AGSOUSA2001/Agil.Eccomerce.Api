using Agil.Eccomerce.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agil.Eccomerce.Api.Data
{
    public partial class DBContext:DbContext
    {
        public DbSet<Cart> Carrito { get; set; }

        public DbSet<Category> Categoria { get; set; }

        public DbSet<Product> Producto { get; set; } 

        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }
    }
}
