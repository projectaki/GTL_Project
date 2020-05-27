using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.ControlLayer
{
    public interface IBookControl
    {
        List<Copy> AvailableCopies(int isbn);
        int CreateBook(IBook book);
        List<Book> LoadBooks();
        List<Book> LoadBooksWhere(int isbn);
        List<Book> SearchBooks(string search = "");
    }
}