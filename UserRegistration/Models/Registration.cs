using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string phoneNo { get; set; }
        public string emailNo { get; set; }
        public int countryName { get; set; }
        public int userCity { get; set; }

        public string userImg { get; set; }
        public string userCV { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
        public string Gender { get; set; }


        public List<Country> countrylist { get; set; }
        public List<City> cityist { get; set; }
    }
}
