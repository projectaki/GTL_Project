using DataLayer;
using DataLayer.ControlLayer;
using GTL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTL_Project.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowPersonLoans()
        {
            ILoanControl lc = Factory.newLoanControl();
            var data = lc.LoadLoans();

            List<ActiveLoan> loans = new List<ActiveLoan>();

            foreach (var item in data)
            {
                loans.Add(new ActiveLoan
                {
                    LoanId = item.Loan_Id,
                    Ssn = item.Ssn,
                    CopyId = item.CopyId,
                    Title = item.Title,
                    LoanDate = item.Loan_Date
                });
            }
            return View(loans);
        }

        [HttpGet]
        public ActionResult ShowPersonLoansWhere(int id)
        {
            ILoanControl lc = Factory.newLoanControl();
            var data = lc.LoadLoansWhere(id);

            List<ActiveLoan> loans = new List<ActiveLoan>();

            foreach (var item in data)
            {
                loans.Add(new ActiveLoan
                {
                    LoanId = item.Loan_Id,
                    Ssn = item.Ssn,
                    CopyId = item.CopyId,
                    Title = item.Title,
                    LoanDate = item.Loan_Date
                });
            }
            return View(loans);
        }
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(ActiveLoan loan,int id)
        {
            if (ModelState.IsValid)
            {
                ILoanControl lc = Factory.newLoanControl();
                lc.AddBook(

                    id,
                    loan.CopyId);
                return RedirectToAction("ShowPersonLoansWhere", new { id = id });
            }
            return View();
        }
    }
}