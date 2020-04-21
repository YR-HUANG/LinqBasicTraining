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
            var totalPrice = 0.0;
            
            foreach (var buyBook in buyList)
            {

                var bookPrice =_books.Where(x => x.Name == buyBook.Key).Select(x => x.Price * x.Discount * (buyBook.Value >= x.Stock ? x.Stock : buyBook.Value)).FirstOrDefault();
                totalPrice += bookPrice;
            }

            return totalPrice;
        }
    }
}