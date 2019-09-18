using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data.product
{
    public class LineProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int lineid { get; set; }
        public string linename { get; set; }
        public string linenote { get; set; }
        public DateTime createday { get; set; }
        public string picture { get; set; }
    }
}
