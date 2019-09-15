using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data;
using ModelClassLibrary.data.roles;
using ModelClassLibrary.respond;
using WebApi.service.user;

namespace WebApi.controllers.user
{
    [Authorize(Roles = Roles.Admin)]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUser m_user;
        public UserController(IUser user)
        {
            m_user = user;
        }
        [HttpGet("get")]
        public DataRespond get()  
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_user.getAll();
                data.messger = "success";
    
            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger =e.Message;
            }

            return data;

        }
        [HttpPost]
        public DataRespond insert(Users user)
        {
            DataRespond data = new DataRespond();
            try
               {
                data.success = true;
                m_user.insert(user);
                data.messger= "success";
            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.messger = e.Message;
            }
                return data;
        }
        [HttpPut]
        public DataRespond update(Users user)
        {

            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                m_user.update(user);
                data.messger = "Success";

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
                m_user.delete(id);
                data.messger = "Success";

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