﻿using Microsoft.AspNetCore.Http;
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
        public double price { get; set; }
        public DateTime createday { get; set; }
        public int lineid { get; set; }
        public int supplierid { get; set; }
    }
}