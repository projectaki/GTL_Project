using GTL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ControlLayer;
using WebGrease;

namespace GTL_Project.Controllers
{
    public class BookController : Controller
    {
 
        public ActionResult Book()
        {
            return View();
        }
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                BookControl.CreateBook(
                    book.Isbn,
                    book.Author,
                    book.Title,
                    book.Description,
                    book.In_Stock,
                    book.Lendable,
                    book.Edition,
                    book.Cover_Type);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult SearchBook()
        {
            var data = BookControl.LoadBooks();

            List<IBook> books = new List<IBook>();

            foreach (var item in data)
            {
                IBook tempBook = MVCFactory.newBook();

                tempBook.Isbn = item.Isbn;
                tempBook.Author = item.Author;
                tempBook.Title = item.Title;
                tempBook.Description = item.Description;
                tempBook.In_Stock = item.In_Stock;
                tempBook.Lendable = item.Lendable;
                tempBook.Edition = item.Edition;
                tempBook.Cover_Type = item.Cover_Type;

                books.Add(tempBook);
                
                    

            }
            return View(books);
        }

        public ActionResult SearchBookWhere(string search)
        {
            var data = BookControl.SearchBooks(search);

            List<Book> books = new List<Book>();

            foreach (var item in data)
            {
                books.Add(new Book
                {
                    Isbn = item.Isbn,
                    Author = item.Author,
                    Title = item.Title,
                    Description = item.Description,
                    In_Stock = item.In_Stock,
                    Lendable = item.Lendable,
                    Edition = item.Edition,
                    Cover_Type = item.Cover_Type
                });
            }
            return View(books);
        }

        [HttpGet]
        public ActionResult BookInfo(int id)
        {
            var data = BookControl.LoadBooksWhere(id);

            List<Book> books = new List<Book>();

            foreach (var item in data)
            {
                books.Add(new Book
                {
                    Isbn = item.Isbn,
                    Author = item.Author,
                    Title = item.Title,
                    Description = item.Description,
                    In_Stock = item.In_Stock,
                    Lendable = item.Lendable,
                    Edition = item.Edition,
                    Cover_Type = item.Cover_Type

                });
            }
            return View(books);
        }

        [HttpGet]
        public ActionResult BookCopies(int id)
        {
            var data = BookControl.AvailableCopies(id);

            List<Copy> copies = new List<Copy>();

            foreach (var item in data)
            {
                copies.Add(new Copy
                {
                    Isbn = item.Isbn,
                    Title = item.Title,
                    Copyid = item.Copyid,
                    Ssn = item.Ssn
                    

                });
            }
            return View(copies);
        }
    }

}
