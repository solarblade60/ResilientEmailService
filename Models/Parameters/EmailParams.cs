using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RupaHealth.Models.Parameters
{
    public class EmailParams
    {
        public string To { get; set; }
        public string To_Name { get; set; }
        public string From { get; set; }
        public string From_Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
