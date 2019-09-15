using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.respond;
using WebApi.service.product;

namespace WebApi.controllers.product
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LineProductController : Controller
    {
        private ILineProduct m_lineProduct;
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
                data.data = m_lineProduct.getAll();
                data.messger = "success";

            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }

            return data;
        }
    }
}