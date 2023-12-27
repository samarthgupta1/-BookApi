using bookapi.Repository;
using bookapi.Models;
using bookapi.Models.Exceptions;



namespace bookapi.Services
{
    public class bookService : IbookService
    {
        IbookRepository bookRepository;
        public bookService(IbookRepository repository)
        {
            bookRepository = repository;
        }

        public book AddBook(book book)
        {
            var b = bookRepository.GetBookById(book.BookId);

            if (b == null)
            {
                return bookRepository.AddBook(book);
            }
            else
                throw new BookAlreadyExistException("Book with id: " + book.BookId + " already exist");
        }

        public bool UpdateBook(int id, book book1)
        {
            var b = bookRepository.GetBookById(id);
            if (b != null)
            {
                return bookRepository.UpdateBook(book1);
            }
            else
                throw new BookNotFoundExceptions("Book with Id: " + id + " does not exist");
        }
        public bool DeleteBook(int id)
        {
            var b = bookRepository.GetBookById(id);
            if (b != null)
            {
                return bookRepository.DeleteBook(id);
            }
            else
                throw new BookNotFoundExceptions("Book with id: " + id + " does not exist");
        }
        public book GetBookById(int id)
        {
            var b = bookRepository.GetBookById(id);
            if (b != null)
            {
                return b;
            }
            else
                throw new BookNotFoundExceptions("Book with id: " + id + " does not exist");
        }
        public List<book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }


    }
}
