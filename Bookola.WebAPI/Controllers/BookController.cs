using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using Pubola.Services;
using Bookola.Models;

namespace Bookola.WebAPI.Controllers.BookController
{
    [Authorize]
    public class BookController : ApiController
    {
        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService(userId);
            return bookService;
        }
        [Route("api/Book/Create")]
        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.CreateBook(book))
            {
                return InternalServerError();
            }
            return Ok("Book was added!");
        }
        [Route("api/Book/GetAll")]
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }
        [Route("api/Book/GetById")]
        public IHttpActionResult GetById(int id)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyId(id);
            return Ok(book);
        }
        [Route("api/Book/GetByTitle")]
        public IHttpActionResult Get(string title)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBooksByTitle(title);
            return Ok(book);
        }
        /*[Route("api/Book/GetByAuthor")]
          public IHttpActionResult GetByAuthor(string author)
          {
              BookService bookService = CreateBookService();
              var book = bookService.GetBookbyAuthor(author);
              return Ok(book);
          }*/
        [Route("api/Book/GetByIsbn")]
        public IHttpActionResult GetByIsbn(long isbn)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyIsbn(isbn);
            return Ok(book);
        }
        [Route("api/Book/GetByAuthorId")]
        public IHttpActionResult GetByAuthorId(int id)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookbyAuthor(id);
            return Ok(book);
        }
        [Route("api/Book/Update")]
        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.UpdateBooks(book))
            {
                return InternalServerError();
            }
            return Ok("Book has been updated!");
        }
        [Route("api/Book/DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookService();
            if (!service.DeleteBook(id))
            {
                return InternalServerError();
            }
            return Ok("Book has been deleted!");
        }
    }
}
