

using System;
using System.ComponentModel.DataAnnotations;

namespace GTL_Project.Models
{
    public class Member
    {
        [Display(Name = "Person ID number")]
        [Range(1000000,9999999,ErrorMessage ="ID has to be 7 digits to be valid!")]
        [Required(ErrorMessage = "You must provide your ID number!")]
        public int Ssn { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must provide your first name!")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must provide your last name!")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You must provide your email address!")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter a valid email address!")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You must provide your Phone number!")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Enter a valid Phone number!")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Campus")]
        [Required(ErrorMessage = "You must provide your campus name!")]
        public string Campus { get; set; }

        public DateTime SignUpDate { get; set; }

        [Display(Name = "Type of Member")]
        [Required(ErrorMessage = "You must provide your member type information!")]
        public string MemberType { get; set; }

    }
}