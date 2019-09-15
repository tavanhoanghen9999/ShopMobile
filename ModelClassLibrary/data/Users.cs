using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary.data
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime createday { get; set; }
        public string password { get; set; }
        public int roleid { get; set; }
    }
}
