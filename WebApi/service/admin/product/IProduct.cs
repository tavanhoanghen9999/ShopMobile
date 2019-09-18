using ModelClassLibrary.data.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.product
{
    public interface IProduct
    {
        IEnumerable<Product> getAll();
        void insert(Product lineProduct);
        void update(Product lineProduct);
        void delete(object id);
        Product getById(object id);
    }
}
