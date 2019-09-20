using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data.customer;
using ModelClassLibrary.data.request;
using ModelClassLibrary.respond;
using WebApi.service.admin.customer;
using WebApi.service.img;

namespace WebApi.controllers.admin.customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomer m_customer;
        private IImage m_image;
        public CustomerController(ICustomer customer,IImage image)
        {
            m_customer = customer;
            m_image = image;
        }
       

        [HttpGet]
        public DataRespond get()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_customer.getAll();
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
        public DataRespond insert(Customer customer)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_customer.insert(customer);
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
        public DataRespond update(Customer customer)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_customer.update(customer);
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
                m_customer.delete(id);
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
        public async Task<string> upfileAsync([FromForm] CustomerRequest file)
        {
            Customer customer = new Customer();
            try
            {
                customer.namecustomer = file.namecustomer;
                customer.phonenumber = file.phonenumber;
                customer.email = file.email;
                customer.address = file.address;
                customer.picture = await m_image.uploadFile(file.picture);
            }
            catch (Exception e)
            {
                customer.namecustomer = e.Message;
            }
            return "update khong thanh chong";
        }

    }
}