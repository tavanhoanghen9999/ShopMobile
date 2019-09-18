using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.product;
using ModelClassLibrary.respond;
using WebApi.service.admin.product;

namespace WebApi.controllers.admin.product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProduct m_product;
        public ProductController(IProduct product)
        {
            m_product = product;
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_product.getAll();
                data.messger = "Success";
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;

            }

            return data;
        }
        [HttpPost]
        public DataRespond insert(Product product)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_product.insert(product);
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
        public DataRespond update(Product product)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_product.update(product);
                data.messger = "Update success";
            }catch(Exception e)
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
                m_product.delete(id);
                data.messger = "Delete success";
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }
            return data;
        }

    }
}