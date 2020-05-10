﻿using DataLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ControlLayer
{
    public static class LoanControl
    {
        public static List<ActiveLoan> LoadLoans()
        {
            string sql = @"select *
                           from Active_Loans;";
            var data = SqlDataAccess.LoadData<ActiveLoan>(sql);
            return data;
        }

        public static List<ActiveLoan> LoadLoansWhere(int ssn)
        {
            var dict = new Dictionary<string, object>
            {
                { "@ssn", ssn }
            };
            string sql = @"select Active_Loans.ssn,Active_Loans.copyid,Book.title,Active_Loans.loan_date from Active_Loans
                          inner join Copy on copy.copyid = Active_Loans.copyid
                          inner join Book on book.isbn = copy.isbn
                          where ssn = @ssn
                          order by loan_date;";

            var data = SqlDataAccess.LoadData<ActiveLoan>(sql,dict);
            return data;
        }

        public static int AddBook(int ssn, int copyid)
        {
            ActiveLoan data = new ActiveLoan
            {
                Ssn = ssn,
                CopyId = copyid
                
            };
            string sql = @"insert into Active_Loans (ssn,copyid,loan_date) values (@Ssn,@CopyId,CURRENT_TIMESTAMP);";

            return SqlDataAccess.SaveData(sql, data);
        }



    }
}
