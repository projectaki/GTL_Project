using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.ControlLayer
{
    public interface IBookControl
    {
        List<Copy> AvailableCopies(int isbn);
        int CreateBook(int isbn, string author, string title, string description, bool in_stock, bool lendable, string edition, string covertype);
        List<Book> LoadBooks();
        List<Book> LoadBooksWhere(int isbn);
        List<Book> SearchBooks(string search = "");
    }
}