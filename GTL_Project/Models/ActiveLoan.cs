using System;

namespace GTL_Project.Models
{
    public class ActiveLoan
    {
        public int LoanId { get; set; }
        public int Ssn { get; set; }
        public int CopyId { get; set; }
        public string Title { get; set; }
        public DateTime LoanDate { get; set; }
    }
}