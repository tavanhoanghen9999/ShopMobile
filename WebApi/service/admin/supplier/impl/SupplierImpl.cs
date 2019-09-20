using ModelClassLibrary.data.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.admin.supplier.impl
{
    public class SupplierImpl:Responsitory<SupplierRequest>,ISupplier
    {
        public SupplierImpl(MyDbContext context) : base(context)
        {

        }
    }
}
