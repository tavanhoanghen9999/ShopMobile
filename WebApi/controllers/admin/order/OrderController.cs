using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.order;
using ModelClassLibrary.data.request;
using ModelClassLibrary.respond;
using WebApi.service.admin.order;

namespace WebApi.controllers.admin.order
{

    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrder m_order;
        public OrderController(IOrder order)
        {
            m_order = order;
        }
        [HttpGet("GetById")]
        public DataRespond OrderGetById(int id)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_order.getById(id);
                data.messger="Success";
            }catch(Exception e)
            {
                data.success = false;
                data.messger = e.Message;
                data.error = e;

            }
            return data;
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
        public DataRespond insert(OrderRequest order)
        {
            DataRespond data = new DataRespond();
            try
            {
                Order or = new Order();
                or.orderid = order.orderid;
                or.email = order.email;
                or.nameorder = order.nameorder;
                or.phonenumber = order.phonenumber;
                or.sumprice = order.sumprice;
                DateTime creday = DateTime.ParseExact(order.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                or.createday = creday;//2019-12-10
                DateTime credaylivi = DateTime.ParseExact(order.daydelivery, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                or.daydelivery= credaylivi;//2019-12-10

                or.address = order.address;
                or.customerid = order.customerid;
                or.activity = order.activity;
                data.success = true;
                m_order.insert(or);
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
        public DataRespond update(OrderRequest order)
        {
            DataRespond data = new DataRespond();
            try
            {
                Order or = m_order.getById(order.orderid);
                or.orderid = order.orderid;
                or.email = order.email;
                or.nameorder = order.nameorder;
                or.phonenumber = order.phonenumber;
                or.sumprice = order.sumprice;
                DateTime creday = DateTime.ParseExact(order.createday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                or.createday = creday;//2019-12-10
                DateTime credaylivi = DateTime.ParseExact(order.daydelivery, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                or.daydelivery = credaylivi;//2019-12-10

                or.address = order.address;
                or.customerid = order.customerid;
                or.activity = order.activity;
                data.success = true;
                m_order.update(or);
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