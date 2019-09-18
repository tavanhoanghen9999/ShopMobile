using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.detailorder;
using ModelClassLibrary.respond;
using WebApi.service.admin.order.impl;

namespace WebApi.controllers.admin.order
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailOrderController : Controller
    {
        private IDetailOrder m_detailOrder;
        public DetailOrderController(IDetailOrder detailOrder)
        {
            m_detailOrder = detailOrder;
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_detailOrder.getAll();
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
        public DataRespond insert(DetailOrder detailOrder)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_detailOrder.insert(detailOrder);
                data.messger = "Insert success";

            }
            catch (Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }
            return data;

        }
        [HttpPut]
        public DataRespond update(DetailOrder detailOrder)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_detailOrder.update(detailOrder);
                data.messger = "Insert success";

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
                m_detailOrder.delete(id);
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