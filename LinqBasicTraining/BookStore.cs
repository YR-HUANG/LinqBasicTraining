using System.Collections.Generic;
using System.Linq;

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
            var totalPrice = (from x in buyList
                join y in _books on x.Key equals y.Name
                select (x.Value * y.Price * y.Discount)).Sum();

            return totalPrice;
        }
    }
}