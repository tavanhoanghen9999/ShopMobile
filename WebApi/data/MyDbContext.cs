using Microsoft.EntityFrameworkCore;
using ModelClassLibrary.data;
using ModelClassLibrary.data.customer;
using ModelClassLibrary.data.detailorder;
using ModelClassLibrary.data.order;
using ModelClassLibrary.data.product;
using ModelClassLibrary.data.supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<LineProduct> LineProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
  

    }
}
