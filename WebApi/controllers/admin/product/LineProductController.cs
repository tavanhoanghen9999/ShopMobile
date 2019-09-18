using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.product;
using ModelClassLibrary.respond;
using WebApi.service.product;

namespace WebApi.controllers.admin.product
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineProductController : Controller
    {
        public readonly ILineProduct m_lineProduct;
        public LineProductController(ILineProduct lineProduct)
        {
            m_lineProduct = lineProduct;
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_lineProduct.getAll();
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
        public DataRespond insert(LineProduct lineProduct)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_lineProduct.insert(lineProduct);
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
        public DataRespond update(LineProduct lineProduct)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_lineProduct.update(lineProduct);
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
                m_lineProduct.delete(id);
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