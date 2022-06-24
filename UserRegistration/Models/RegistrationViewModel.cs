using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }

        public string phone { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int cityId { get; set; }
        public int countryId { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

        public string password { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }


        public string userImg { get; set; }

        public string userCV { get; set; }
    }
}
