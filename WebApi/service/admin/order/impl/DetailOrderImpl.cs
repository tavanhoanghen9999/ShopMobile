using ModelClassLibrary.data.detailorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.responsitory.impl;

namespace WebApi.service.admin.order.impl
{
    public class DetailOrderImpl:Responsitory<DetailOrder>,IDetailOrder
    {
        public DetailOrderImpl(MyDbContext context) : base(context)
        {

        }
    }
}
