

using System;

namespace GTL_Project.Models
{
    public class Member
    {
        public int Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Campus { get; set; }
        public DateTime SignUpDate { get; set; }
        public string MemberType { get; set; }

    }
}