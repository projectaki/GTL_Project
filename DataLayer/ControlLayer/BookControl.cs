using DataLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ControlLayer
{
    public static class BookControl
    {
        public static int CreateBook(int isbn, string author, string title, string description,
            bool in_stock, bool lendable, string edition, string covertype)
        {
            IBook data = Factory.newBook();

            data.Isbn = isbn;
            data.Author = author;
            data.Title = title;
            data.Description = description;
            data.In_Stock = in_stock;
            data.Lendable = lendable;
            data.Edition = edition;
            data.Cover_Type = covertype;

            string sql = @"insert into dbo.Book (isbn,author,title,description,in_stock,lendable,edition,cover_type) values (
                               @Isbn,@Author,@Title,@Description,@In_stock,@Lendable,@edition,@cover_type);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<IBook> LoadBooks()
        {
            string sql = @"select *
                           from book;";
            var data = SqlDataAccess.LoadData<IBook>(sql);
            return data;
        }

        public static List<Book> LoadBooksWhere(int isbn)
        {
           
            var dict = new Dictionary<string, object>
            {
                { "@isbn", isbn }
            };
            
            string sql = @"select *
                           from book
                           where isbn = @isbn;";
            
            var data = SqlDataAccess.LoadData<Book>(sql,dict);
            return data;
        }

        public static List<Book> SearchBooks(string search = "")
        {
            var dict = new Dictionary<string, object>
            {
                { "@search", search }
            };

            string sql = @"select * from book
                           where title like CONCAT('%',@search,'%')
                           order by title;";

            var data = SqlDataAccess.LoadData<Book>(sql,dict);
            return data;
        }

        public static List<Copy> AvailableCopies(int isbn)
        {
            var dict = new Dictionary<string, object>
            {
                { "@isbn", isbn }
            };

            string sql = @"select Copy.isbn,Book.title,Copy.copyid,Active_Loans.ssn
                            from Copy
                            inner join Book on Book.isbn = Copy.isbn
                            left join Active_Loans on Active_Loans.copyid = Copy.copyid
                            where book.isbn = @isbn and ssn is null
                            order by copyid;";

            var data = SqlDataAccess.LoadData<Copy>(sql,dict);
            return data;
        }

    }
}
