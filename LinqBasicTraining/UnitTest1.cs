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

        [TestMethod]
        public void GetPrice()
        {
            GivenBooks();
            var bookStore = new BookStore(_books);
            var buyList = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("a", 3),
                new KeyValuePair<string, int>("b", 2),
                new KeyValuePair<string, int>("c", 3),
                new KeyValuePair<string, int>("d", 1),
            };
            var totalPrice = bookStore.GetPrice(buyList);
            Assert.AreEqual( 100*3*0.9+150*2*0.7+300*3*0.8+400*1*0.9,totalPrice);
        }


        private void GivenBooks()
        {
            _books = new List<Book>()
            {
                new Book() {Name = "a", Price = 100 , Discount = 0.9},
                new Book() {Name = "b", Price = 150 , Discount = 0.7},
                new Book() {Name = "c", Price = 300 , Discount = 0.8},
                new Book() {Name = "d", Price = 400 , Discount = 0.9},
            };
        }
    }
}
