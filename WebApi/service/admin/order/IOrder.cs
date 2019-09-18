using ModelClassLibrary.data.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.order
{
    public interface IOrder
    {
        IEnumerable<Order> getAll();
        void insert(Order order);
        void update(Order order);
        void delete(object id);
        Order getById(object id);
    }
}
