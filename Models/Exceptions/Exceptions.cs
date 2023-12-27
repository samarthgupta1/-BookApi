namespace bookapi.Models.Exceptions
{
    public class BookNotFoundExceptions : ApplicationException
    {
        public BookNotFoundExceptions()
        {

        }
        public BookNotFoundExceptions(string message) : base(message) { }

    }
    public class BookAlreadyExistException : ApplicationException
    {
        public BookAlreadyExistException()
        {

        }
        public BookAlreadyExistException(string message) : base(message) { }

    }
}
