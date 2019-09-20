﻿using System;
using System.Collections.Generic;
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
        [HttpPost]
        public async Task<string> upfileAsync([FromForm] LineProductRequest file)
        {
            LineProduct lineProduct = new LineProduct();
            try
            {
                lineProduct.linename = file.linename;
                lineProduct.linenote = file.linenote;
                lineProduct.createday = file.createday;
                lineProduct.picture = await m_image.uploadFile(file.picture);
               
            }
            catch (Exception e)
            {
                
            }
            return "update khong thanh chong";
        }
    }
}