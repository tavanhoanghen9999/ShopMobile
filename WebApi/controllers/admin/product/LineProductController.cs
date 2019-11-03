using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.product;
using ModelClassLibrary.data.request;
using ModelClassLibrary.respond;
using WebApi.service.img;
using WebApi.service.product;

namespace WebApi.controllers.admin.product
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineProductController : Controller
    {
        public readonly ILineProduct m_lineProduct;
        private IImage m_image;
        public LineProductController(ILineProduct lineProduct,IImage image)
        {
            m_lineProduct = lineProduct;
            m_image = image;
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data=m_lineProduct.getAll();
                data.messger = "Success";

            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }

            return data;
        }
        [HttpGet("getbyid")]
        public DataRespond getById(int id)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data=m_lineProduct.getById(id);
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

        [HttpPost("insertlineproduct")]
        public async Task<DataRespond> insertAsync([FromForm]LineProductRequest lineProduct)
        {
            DataRespond data = new DataRespond();
            try
            {
                LineProduct l = new LineProduct();
                l.linename = lineProduct.linename;
                l.linenote = lineProduct.linenote;
                DateTime createday = DateTime.ParseExact(lineProduct.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                l.createday = createday;//2019-12-10
                l.picture = await m_image.uploadFilelineproduct(lineProduct.picture);
                data.success = true;
                data.messger = "update success";
                m_lineProduct.insert(l);
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }
            return data;
        }

        [HttpPut]
        public async Task<DataRespond> updatetAsync([FromForm]LineProductRequest lineProduct)
        {
            DataRespond data = new DataRespond();
            try
            {
                LineProduct lp = m_lineProduct.getById(lineProduct.lineid);
                lp.linename = lineProduct.linename;
                lp.linenote = lineProduct.linenote;
                DateTime createday = DateTime.ParseExact(lineProduct.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                lp.createday = createday;
                if (lineProduct.picture != null)
                {
                    m_image.deleteFile(lp.picture);
                    lp.picture = await m_image.uploadFilelineproduct(lineProduct.picture);
                }
                data.success = true;
                m_lineProduct.update(lp);
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

        [HttpPost]
        public async Task<string> upfileAsync([FromForm] LineProductRequest file)
        {
            LineProduct lineProduct = new LineProduct();
            try
            {
                lineProduct.linename = file.linename;
                lineProduct.linenote = file.linenote;
                lineProduct.createday = DateTime.ParseExact(file.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                lineProduct.picture = await m_image.uploadFilelineproduct(file.picture);
               
            }
            catch (Exception e)
            {
                lineProduct.picture = e.Message;
            }
            return "update khong thanh chong";
        }
    }
}