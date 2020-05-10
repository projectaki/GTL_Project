using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Member
    {
        public int ssn { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mail_address { get; set; }
        public string phone_nr { get; set; }
        public string campus { get; set; }
        public DateTime sign_up_date { get; set; }
        
        public string member_type { get; set; }
        
    }
}
