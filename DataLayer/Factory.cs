using DataLayer.ControlLayer;
using DataLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Factory
    {

        public static IBook newBook()
        {
            return new Book();
        }

        public static IBookControl newBookControl()
        {
            return new BookControl(new SqlDataAccess());
        }

        public static ILoanControl newLoanControl()
        {
            return new LoanControl(new SqlDataAccess());
        }

        public static IMemberControl newMemberControl()
        {
            return new MemberControl(new SqlDataAccess());
        }

    }
}
