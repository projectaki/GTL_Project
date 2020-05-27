using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using DataLayer;
using DataLayer.ControlLayer;
using DataLayer.DataAccess;
using DataLayer.Models;
using Moq;
using Xunit;

namespace TestClasses
{
    public class TestBooks
    {

        [Fact]
        public void loadBooks()
        {

            var mock = new Mock<ISqlDataAccess>();
            var books = GetBooks();

            mock.Setup(x => x.LoadData<Book>("select * from book"))
            .Returns(books);

            var expected = GetBooks();


            var bc = new BookControl(mock.Object);

            var actual = bc.LoadBooks();
            

            Assert.True(actual != null);
            Assert.Equal(expected.Count, actual.Count);
            
            

        }

        [Fact]
        public void saveBooks()
        {

            var mock = new Mock<ISqlDataAccess>();
            IBook book = GetBooks()[0];

            string sql = @"insert into dbo.Book (isbn,author,title,description,in_stock,lendable,edition,cover_type) values (
                               @Isbn,@Author,@Title,@Description,@In_stock,@Lendable,@edition,@cover_type);";

            mock.Setup(x => x.SaveData(sql, book));
  
            var bc = new BookControl(mock.Object);

            bc.CreateBook(book);
            

            mock.Verify(x => x.SaveData(sql, book), Times.Once);



        }

        private List<Book> GetBooks()
        {
            List<Book> booklist = new List<Book>
            {
                new Book
                {
                    Isbn = 1,
                    Author = "test",
                    Title = "test",
                    Description = "test",
                    In_Stock = true,
                    Lendable = true,
                    Edition = "test",
                    Cover_Type = "test"
                },
                new Book
                {
                    Isbn = 2,
                    Author = "test",
                    Title = "test",
                    Description = "test",
                    In_Stock = true,
                    Lendable = true,
                    Edition = "test",
                    Cover_Type = "test"
                }

             };
            return booklist;

         }
    }
}