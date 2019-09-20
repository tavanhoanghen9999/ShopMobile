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
        public int phonenumber { get; set; }
        public IFormFile picture { get; set; }
    }
}
