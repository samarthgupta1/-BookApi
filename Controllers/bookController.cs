using Microsoft.AspNetCore.Mvc;
using bookapi.Models;
using bookapi.Models.Exceptions;
using bookapi.Services;
using Microsoft.AspNetCore.Http;


namespace bookapi.Controllers
{ 
        [ApiController]
        public class booksController : ControllerBase
        {
            IbookService bookService;
            public booksController(IbookService service)
            {
                bookService = service;
            }
            [HttpGet]
            [Route("/api/books")]
            public ActionResult GetAllBooks()
            {
                return Ok(bookService.GetAllBooks());
            }
            [HttpGet]
            [Route("/api/books/{id}")]
            public ActionResult GetBookById(int id)
            {
                try
                {
                    var b = bookService.GetBookById(id);
                    return Ok(b);
                }
                catch (BookNotFoundExceptions ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            [HttpPost]
            [Route("/api/books")]
            public ActionResult AddBook([FromBody]book  book1)
            {
                try
                {
                    var b = bookService.AddBook(book1);
                    return Created("created", b);
                }
                catch (BookAlreadyExistException ex)
                {
                    return Conflict(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpPut]
            [Route("/api/book/{id}")]
            public ActionResult UpdateBook(int id, [FromBody] book book1)
            {
                try
                {

                    return Ok(bookService.UpdateBook(id, book1));
                }
                catch (BookNotFoundExceptions ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [HttpDelete]
            [Route("/api/books/{id}")]
            public ActionResult DeleteBook(int id)
            {
                try
                {
                    return Ok(bookService.DeleteBook(id));
                }
                catch (BookNotFoundExceptions ex)
                {
                    return NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    
}
