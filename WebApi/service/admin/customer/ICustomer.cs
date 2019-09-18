using ModelClassLibrary.data.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.customer
{
    public interface ICustomer
    {
        IEnumerable<Customer> getAll();
        void insert(Customer customer);
        void update(Customer customer);
        void delete(object id);
       Customer getById(object id);
    }
}
