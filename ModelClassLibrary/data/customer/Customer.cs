using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.customer
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int customerid { get; set; }
        public string namecustomer { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string picture { get; set; }
        public Boolean activity { get; set; }
    }
}
