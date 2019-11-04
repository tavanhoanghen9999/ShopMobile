using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.order
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int orderid { get; set; }
        public string nameorder { get; set; }
        public string address { get; set; }
        public DateTime createday { get; set; }
        public DateTime daydelivery { get; set; }
        public string phonenumber { get; set; }
        public long sumprice { get; set; }
        public int customerid { get; set; }
        public Boolean activity { get; set; }
        public string email { get; set; }

    }
}
