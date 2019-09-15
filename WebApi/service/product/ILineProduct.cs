using ModelClassLibrary.data.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.product
{

    public interface ILineProduct
    {
        IEnumerable<LineProduct> getAll();
        void insert(LineProduct lineProduct);
        void update(LineProduct lineProduct);
        void delete(object id);
        LineProduct getById(object id);
      
    }
}
