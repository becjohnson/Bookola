using Bookola.Models.Book;
using Microsoft.AspNet.Identity;
using Pubola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers.BookController
{
    [Authorize]
    public class BookController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookService noteService = CreateBookService();
            var notes = noteService.GetBooks();
            return Ok(notes);
        }
        public IHttpActionResult Post(BookCreate note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.CreateBook(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new BookService(userId);
            return noteService;
        }
        public IHttpActionResult Get(string title)
        {
            BookService noteService = CreateBookService();
            var note = noteService.GetBookByTitle(title);
            return Ok(note);
        }
        public IHttpActionResult Put(BookEdit note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateBookService();
            if (!service.UpdateBooks(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(string title)
        {
            var service = CreateBookService();
            if (!service.DeleteBook(title))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
