using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary.respond
{
    public class DataRespond  //su dung cho tat ca
    {
        public Boolean success { get; set; }
        public dynamic data { get; set; }
        public dynamic error { get; set; }
        public dynamic messger { get; set; }

    }
}
