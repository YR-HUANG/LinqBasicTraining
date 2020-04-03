using System.Collections.Generic;
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
                new Book() {Name = "a"},
                new Book() {Name = "a"},
                new Book() {Name = "b"},
                new Book() {Name = "c"},
                new Book() {Name = "d"},
                new Book() {Name = "e"},
                new Book() {Name = "f"},
                new Book() {Name = "g"},
                new Book() {Name = "h"},
            };
        }
    }
}
