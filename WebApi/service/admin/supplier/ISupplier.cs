using ModelClassLibrary.data.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.service.admin.supplier
{
    public interface ISupplier
    {
        IEnumerable<SupplierRequest> getAll();
        void insert(SupplierRequest supplier);
        void update(SupplierRequest supplier);
        void delete(object id);
        SupplierRequest getById(object id);
    }
}
