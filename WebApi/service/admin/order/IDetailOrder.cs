using ModelClassLibrary.data.detailorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.order.impl
{
    public interface IDetailOrder
    {
        IEnumerable<DetailOrder> getAll();
        void insert(DetailOrder detailOrder);
        void update(DetailOrder detailOrder);
        void delete(object id);
        DetailOrder getById(object id);
    }
}
