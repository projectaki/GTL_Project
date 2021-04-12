using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.ControlLayer
{
    public interface ILoanControl
    {
        int AddBook(int ssn, int copyid);
        List<ActiveLoan> LoadLoans();
        List<ActiveLoan> LoadLoansWhere(int ssn);

        List<FinishedLoans> LoadStatistics();
        int ReturnBook(int copyid);
    }
}