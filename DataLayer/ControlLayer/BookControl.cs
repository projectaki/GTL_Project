﻿using DataLayer.DataAccess;
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
            Book data = new Book
            {
                Isbn = isbn,
                Author = author,
                Title = title,
                Description = description,
                In_Stock = in_stock,
                Lendable = lendable,
                Edition = edition,
                Cover_Type = covertype
            };
            string sql = @"insert into dbo.Book (isbn,author,title,description,in_stock,lendable,edition,cover_type) values (
                               @Isbn,@Author,@Title,@Description,@In_stock,@Lendable,@edition,@cover_type);";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<Book> LoadBooks()
        {
            string sql = @"select *
                           from book;";
            var data = SQLDataAccess.LoadData<Book>(sql);
            return data;
        }

        public static List<Book> LoadBooksWhere(int isbn)
        {
            string sql = @"select *
                           from book
                           where isbn =" + isbn + ";";
            var data = SQLDataAccess.LoadData<Book>(sql);
            return data;
        }

        public static List<Book> SearchBooks(string search)
        {
            
            string sql = "select * from book" + " where title like" + "'" + "%" + search + "%" + "'" + " order by title;";

            var data = SQLDataAccess.LoadData<Book>(sql);
            return data;
        }

        public static List<Copy> AvailableCopies(int isbn)
        {

            string sql = "select Copy.isbn,Book.title,Copy.copyid,Active_Loans.ssn" +
            " from Copy" +
            " inner join Book on Book.isbn = Copy.isbn" +
            " left join Active_Loans on Active_Loans.copyid = Copy.copyid" +
            " where book.isbn =" + isbn + "and ssn is null" +
            " order by copyid;";

            var data = SQLDataAccess.LoadData<Copy>(sql);
            return data;
        }

    }
}
