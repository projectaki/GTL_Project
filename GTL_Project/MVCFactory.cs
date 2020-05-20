using GTL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTL_Project
{
    public static class MVCFactory
    {
        public static IBook newBook()
        {
            return new Book();        
        }

    }
}