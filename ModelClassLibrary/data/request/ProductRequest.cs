using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
    public class ProductRequest
    {
        public int productid { get; set; }
        public string nameproduct { get; set; }
        public string note { get; set; }
        public IFormFile picture { get; set; }
        public int total { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public string createday { get; set; }
        public int activity { get; set; }
        public int lineid { get; set; }
        public int supplierid { get; set; }
    }
}
