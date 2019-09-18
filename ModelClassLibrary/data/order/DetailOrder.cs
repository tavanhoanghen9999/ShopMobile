using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.detailorder
{
    public class DetailOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int detailorderid { get; set; }
        public int total { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
    }
}
