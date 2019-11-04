using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.data.request
{
    class DetailOrderRequest
    {
        public int detailorderid { get; set; }
        public int total { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public int activity { get; set; }
    }
}
