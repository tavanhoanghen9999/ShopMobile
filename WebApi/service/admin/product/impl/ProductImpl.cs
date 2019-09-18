using ModelClassLibrary.data.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.admin.product.impl
{
    public class ProductImpl : Responsitory<Product>, IProduct
    {
        public ProductImpl(MyDbContext context) : base(context)
        {
        }
    }
}
