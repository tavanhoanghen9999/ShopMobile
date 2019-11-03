using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
    public  class SupplierRequest
    {
        public int supplierid { get; set; }
        public string suppliername { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string createday { get; set; }
        public IFormFile picture { get; set; }
        public int  activity { get; set; }
    }
}
