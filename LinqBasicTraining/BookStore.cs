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