using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.request;
using ModelClassLibrary.data.supplier;
using ModelClassLibrary.respond;
using WebApi.service.admin.supplier;
using WebApi.service.img;

namespace WebApi.controllers.admin.supplier
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private ISupplier m_supplier;
        private IImage m_image;
        public SupplierController(ISupplier supplier,IImage image)
        {
            m_supplier = supplier;
            m_image = image;
        }

        [HttpPost]
        public async Task<string> upfileAsync([FromForm] SupplierRequest file)
        {
            Supplier supplier  = new Supplier();
            try
            {
                supplier.suppliername = file.suppliername;
                supplier.phonenumber = file.phonenumber;
                supplier.address = file.address;
                supplier.email = file.email;
                supplier.createday = DateTime.ParseExact(file.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                supplier.picture = await m_image.uploadFile(file.picture);
            }
            catch (Exception e)
            {
                supplier.picture = e.Message;
            }
            return "update khong thanh chong";
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                
                data.success = true;
                data.data=m_supplier.getAll();
                data.messger = "Success";
            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;

            }

            return data;
        }
        [HttpPost]
        public async Task<DataRespond> insertAsync([FromForm]SupplierRequest supplier)
        {
            DataRespond data = new DataRespond();
            try
            {
                Supplier s = new Supplier();
                s.suppliername = supplier.suppliername;
                s.phonenumber = supplier.phonenumber;
                s.email = supplier.email;
                DateTime createday = DateTime.ParseExact(supplier.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                s.createday = createday;//2019-12-10
                s.picture = await m_image.uploadFile(supplier.picture);
                data.success = true;
                m_supplier.insert(s);
                data.messger = "Insert success";

            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }

            return data;
        }
        [HttpPut]
        public DataRespond update(Supplier supplier)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_supplier.update(supplier);
                data.messger = "Update success";

            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }

            return data;
        }
        [HttpDelete]
        public DataRespond delete(int id)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_supplier.delete(id);
                data.messger = "Delete success";

            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }

            return data;
        }


    }
}