using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitPro_Backend.Models.request
{
    public class CustomerRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string notes { get; set; }

    }
}
