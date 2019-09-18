using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.supplier
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int supplierid { get; set; }
        public string suppliername { get; set; }
        public string address { get; set; }
        public int phonenumber { get; set; }
        public string picture { get; set; }
    }
}
