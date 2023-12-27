using bookapi.Models;


namespace bookapi.Repository
{
    public interface IbookRepository
    {
        public book AddBook(book book);
        public bool DeleteBook(int id);
        public book GetBookById(int id);
        public bool UpdateBook(book book);
        public List<book> GetAllBooks();
    }
}
