using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class RegistrationViewModel
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
