using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WebModel
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Mail { get; set; }
        public string AccessKey { get; set; }
        public string ProfileText { get; set; }
        public List<Review> ReviewList { get; set; }
    }
}
