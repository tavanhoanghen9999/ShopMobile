using ModelClassLibrary.data.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.product.impl
{
    public class LineProductImpl : Responsitory<LineProduct>, ILineProduct
    {
        public LineProductImpl(MyDbContext context) : base(context)
        {
        }
    }
}
