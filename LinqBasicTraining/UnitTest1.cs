using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqBasicTraining
{
    [TestClass]
    public class UnitTest1
    {
        private List<Book> _books;


        [TestMethod]
        public void GetReceipt()
        {
            GivenBooks();
            var bookStore = new BookStore(_books);
            var buyBook = bookStore.BuyBook("Dustin","b");
            Assert.AreEqual("Customer : Dustin, Book Name : b",buyBook);
        }

        private void GivenBooks()
        {
            _books = new List<Book>()
            {
                new Book() {name = "a"},
                new Book() {name = "a"},
                new Book() {name = "b"},
                new Book() {name = "c"},
                new Book() {name = "d"},
                new Book() {name = "e"},
                new Book() {name = "f"},
                new Book() {name = "g"},
                new Book() {name = "h"},
            };
        }
    }

    public class Book
    {
        public string name { get; set; }

    }

    public class BookStore
    {
        private readonly List<Book> _books;

        public BookStore(List<Book> books)
        {
            _books = books;
        }

        public Book GetBookByName(string bookName)
        {
           return _books.Where(x => x.name == bookName).FirstOrDefault();
        }

        public string BuyBook(string customerName, string bookName)
        {
            return _books.Where(x => x.name == bookName).Select(x => $"Customer : {customerName} Book Name : {x.name}").FirstOrDefault();
        }
    }
}
