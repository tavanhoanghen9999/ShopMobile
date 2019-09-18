using ModelClassLibrary.data.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.admin.customer.impl
{
    public class CustomerImpl : Responsitory<Customer>, ICustomer
    {
        public CustomerImpl(MyDbContext context) : base(context)
        {
        }
    }
}
