using bookapi.Models;


namespace bookapi.Repository
{
        public class bookRepository : IbookRepository
        {
            bookDBContext _context;
            public bookRepository(bookDBContext bookDBContext)
            {
                _context = bookDBContext;
            }


            public book AddBook(book book)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return book;
            }

            public bool DeleteBook(int id)
            {
                _context.Books.Remove(_context.Books.Find(id));
                _context.SaveChanges();
                return true;
            }

            public book GetBookById(int id)
            {
                return _context.Books.Find(id);
            }

            public bool UpdateBook(book book1)
            {
                var b = _context.Books.Where(x=>x.BookId==book1.BookId).FirstOrDefault();
                if (b != null)
                {
                 b.Title = book1.Title;
                 b.Auther = book1.Auther;
                 b.ISBN = book1.ISBN;
                _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            public List<book> GetAllBooks()
            {
                return _context.Books.ToList();
            }
        }
    
}

