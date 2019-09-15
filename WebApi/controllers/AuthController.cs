using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.data;
using ModelClassLibrary.respond;
using WebApi.service.auth;

namespace WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuth m_auth;
        public AuthController(IAuth auth)
        {
            m_auth = auth;
        }
        [HttpPost]
        public DataRespond login(Auth auth)
        {

            DataRespond data = new DataRespond();
            try
            {
                data = m_auth.login(auth);

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