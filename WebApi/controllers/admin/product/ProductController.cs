using System;
using System.Collections.Generic;
using System.Globalization;
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
                DateTime cday = DateTime.ParseExact(file.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pr.createday = cday;
                pr.note = file.note;
                pr.price = file.price;
                pr.total = file.total;
                pr.discount = file.discount;
                pr.activity = file.activity==0?true: false ;
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
                data.data=m_product.getAll();
                data.messger = "Success";
            }catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;

            }

            return data;
        }
        [HttpPost("insertproduct")]
        public async Task<DataRespond> insertAsync([FromForm]ProductRequest product)
        {
            DataRespond data = new DataRespond();
            try
            {
                Product p = new Product();
                p.nameproduct = product.nameproduct;
                p.note = product.note;
                p.price = product.price;
                p.discount = product.discount;
                p.activity = product.activity == 0 ? true : false;
                DateTime cday = DateTime.ParseExact(product.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                p.createday = cday;
                p.picture = await m_image.uploadFile(product.picture);
                p.lineid = product.lineid;
                p.supplierid = product.supplierid;

                data.success = true;
                m_product.insert(p);
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
        public async Task<DataRespond> updateAsync([FromForm]ProductRequest product)
        {
            DataRespond data = new DataRespond();
            try
            {
                Product pr = m_product.getById(product.productid);
                pr.nameproduct = product.nameproduct;
                pr.note = product.note;
                pr.price = product.price;
                pr.discount = product.discount;
                pr.activity = product.activity == 0 ? true : false;
                DateTime cday = DateTime.ParseExact(product.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pr.createday = cday;
                pr.picture = await m_image.uploadFile(product.picture);
                pr.lineid = product.lineid;
                pr.supplierid = product.supplierid;

                data.success = true;
                m_product.update(pr);
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