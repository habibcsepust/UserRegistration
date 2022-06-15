using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class City
    {
        public int Id { get; set; }
        public string cityName { get; set; }
        public int CountryId { get; set; }
    }
}
