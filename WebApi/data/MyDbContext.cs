using Microsoft.EntityFrameworkCore;
using ModelClassLibrary.data;
using ModelClassLibrary.data.product;
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
        public DbSet<LineProduct> LineProduct { get; set; }

    }
}
