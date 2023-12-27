
using bookapi.Models;



namespace bookapi.Services
{
    public interface IbookService
    {
        public book AddBook(book book);
        public bool UpdateBook(int id, book book);
        public bool DeleteBook(int id);
        public book GetBookById(int id);
        public List<book> GetAllBooks();
    }
}
