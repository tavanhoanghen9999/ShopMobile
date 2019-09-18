using ModelClassLibrary.data.supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.supplier.impl
{
    public class SupplierIimpl:Responsitory<Supplier>,ISupplier
    {
        public SupplierIimpl(MyDbContext context) : base(context)
        {
        }
    }
}
