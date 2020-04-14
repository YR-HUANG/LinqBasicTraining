using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;

namespace LinqBasicTraining
{
    public class BookStore
    {
        private readonly List<Book> _books;

        public BookStore(List<Book> books)
        {
            _books = books;
        }

        public string BuyBook(string customerName, string bookName)
        {
            return _books.Where(x => x.Name == bookName).Select(x => $"Customer : {customerName}, Book Name : {x.Name}").FirstOrDefault();
        }

        public double GetPrice(List<KeyValuePair<string, int>> buyList)
        {
            double totalPrice = 0;
           
            foreach (var buyBook in buyList)
            {
                var bookCount =buyBook.Value;
                var myBook = _books.FirstOrDefault(x=>x.Name==buyBook.Key);
                totalPrice = GetBookPrice(buyBook, myBook, totalPrice);
            }
     
            return totalPrice;
        }

        private static double GetBookPrice(KeyValuePair<string, int> buyBook, Book myBook, double totalPrice)
        {
            int bookCount;
            if (buyBook.Value <= myBook.Stock)
            {
                bookCount = buyBook.Value;
            }
            else
            {
                bookCount = myBook.Stock;
            }

            totalPrice += myBook.Price * myBook.Discount * bookCount;
            return totalPrice;
        }
    }
}