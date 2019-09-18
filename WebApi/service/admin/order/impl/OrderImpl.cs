using ModelClassLibrary.data.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.admin.order.impl
{
    public class OrderImpl:Responsitory<Order>,IOrder
    {
        public OrderImpl(MyDbContext context) : base(context)
        {
        }
    }
}
