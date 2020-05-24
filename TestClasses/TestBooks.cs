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
            

            mock.Setup(x => x.LoadData<Book>("select * from book"))
            .Returns(GetBooks());

            var expected = GetBooks();


            var bc = new BookControl(mock.Object);

            var actual = bc.LoadBooks();
            

            Assert.True(actual != null);
            Assert.Equal(expected.Count, actual.Count);
            
            

        }

        private List<Book> GetBooks()
        {
            List<Book> booklist = new List<Book>
            {
                new Book
                {
                    Isbn = 1
                },
                new Book
                {
                    Isbn = 2
                }

             };
            return booklist;

         }
    }
}