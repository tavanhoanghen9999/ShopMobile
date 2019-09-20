using System;
using System.Collections.Generic;
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
                m_supplier.getAll();
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
        public DataRespond insert(SupplierRequest supplier)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_supplier.insert(supplier);
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
        public DataRespond update(SupplierRequest supplier)
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