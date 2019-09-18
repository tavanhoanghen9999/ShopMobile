using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
    public class LineProduct
    {
        public int lineid { get; set; }
        public string linename { get; set; }
        public string linenote { get; set; }
        public DateTime createday { get; set; }
        public IFormFile picture { get; set; }
    }
}
