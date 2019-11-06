using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
   public class OrderRequest
    {
        public int orderid { get; set; }
        public string nameorder { get; set; }
        public string address { get; set; }
        public string createday { get; set; }
        public string daydelivery { get; set; }
        public string phonenumber { get; set; }
        public int sumprice { get; set; }
        public int customerid { get; set; }
        public int activity { get; set; }
        public string email { get; set; }
    }
}
