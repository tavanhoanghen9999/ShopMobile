using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.order;
using ModelClassLibrary.respond;
using WebApi.service.admin.order;

namespace WebApi.controllers.admin.order
{
    public class OrderController : Controller
    {
        private IOrder m_order;
        public OrderController(IOrder order)
        {
            m_order = order;
        }
        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data=m_order.getAll();
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
        public DataRespond insert(Order order)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_order.insert(order);
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
        public DataRespond update(Order order)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_order.update(order);
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
                m_order.delete(id);
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