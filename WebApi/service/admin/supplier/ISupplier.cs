using ModelClassLibrary.data.request;
using ModelClassLibrary.data.supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.supplier
{
    public interface ISupplier
    {
        IEnumerable<Supplier> getAll();
        void insert(Supplier supplier);
        void update(Supplier supplier);
        void delete(object id);
        Supplier getById(object id);
    }
}
