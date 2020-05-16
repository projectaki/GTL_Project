using System;
using System.ComponentModel.DataAnnotations;

namespace GTL_Project.Models
{
    public class ActiveLoan
    {
        public int LoanId { get; set; }
        public int Ssn { get; set; }
        [Display(Name = "Copy ID")]
        [Range(1, 99999999999)]
        public int CopyId { get; set; }
        public string Title { get; set; }
        public DateTime LoanDate { get; set; }
    }
}