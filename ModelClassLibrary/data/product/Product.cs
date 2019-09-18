using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.product
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int productid { get; set; }
        public string nameproduct { get; set; }
        public string note { get; set; }
        public string picture { get; set; }
        public int total { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public DateTime createday { get; set; }
        public int lineid { get; set; }
        public int supplierid { get; set; }
    }
}
