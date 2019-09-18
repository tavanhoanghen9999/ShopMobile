using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
    public class Customer
    {
        public int customerid { get; set; }
        public string namecustomer { get; set; }
        public int phonenumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public IFormFile picture { get; set; }
    }
}
