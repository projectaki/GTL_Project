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

    }
}
