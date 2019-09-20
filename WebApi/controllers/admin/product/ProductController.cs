using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.product;
using ModelClassLibrary.data.request;
using ModelClassLibrary.respond;
using WebApi.service.admin.product;
using WebApi.service.img;

namespace WebApi.controllers.admin.product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProduct m_product;
        private IImage m_image;
        public ProductController(IProduct product, IImage image)
        {
            m_product = product;
            m_image = image;
        }
        [HttpPost]
        public async Task<string> upfileAsync([FromForm] ProductRequest file)
        {
            Product pr = new Product();
            try
            {
                pr.nameproduct = file.nameproduct;
                pr.createday = file.createday;
                pr.note = file.note;
                pr.price = file.price;
                pr.total = file.total;
                pr.productid = file.productid;
                pr.supplierid = file.supplierid;
                pr.picture = await m_image.uploadFile(file.picture);//
            }
            catch (Exception e)
            {
                pr.picture = e.Message;
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