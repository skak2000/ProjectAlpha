using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WebModel
{
    public class Company
    {
        public Guid CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string OpeningHours { get; set; }

        public List<Review> ReviewList { get; set; }

        public string GetGoogleMapLink()
        {
            string urlSearch = Uri.EscapeUriString(Name + Address + ZipCode);
            string respont = $"https://maps.google.com/maps?q=" + urlSearch + "&t=&z=13&ie=UTF8&iwloc=&output=embed";
            return respont;
        }
    }
}
