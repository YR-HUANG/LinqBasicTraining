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
                var myBook = _books.FirstOrDefault(x=>x.Name==buyBook.Key);
                if (buyBook.Value <= myBook.Stock)
                {
                    totalPrice += myBook.Price * myBook.Discount * buyBook.Value;
                }
                else
                {
                    totalPrice += myBook.Price * myBook.Discount * myBook.Stock;
                }
                
            }
            //foreach (double d in (buyList.Join(_books, x => x.Key, y => y.Name,
            //    (x, y) => (x.Value * y.Price * y.Discount))))
            //{
            //    totalPrice += d;
            //}


            return totalPrice;
        }
    }
}