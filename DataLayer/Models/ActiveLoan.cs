using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ActiveLoan
    {
        public int Loan_Id { get; set; }
        public int Ssn { get; set; }
        public int CopyId { get; set; }
        public string Title { get; set; }
        public DateTime Loan_Date { get; set; }


    }
}
