using Bookola.Models;
using Bookola.Models.Genre;
using Microsoft.AspNet.Identity;
using Pubola.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookola.WebAPI.Controllers.GenreController
{
    [Authorize]
    public class GenreController : ApiController
    {
        public IHttpActionResult Get()
        {
            GenreService noteService = CreateGenreService();
            var notes = noteService.GetGenres();
            return Ok(notes);
        }
        public IHttpActionResult Post(GenreCreate note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGenreService();
            if (!service.CreateGenre(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new GenreService(userId);
            return noteService;
        }
        public IHttpActionResult Get(int id)
        {
            GenreService noteService = CreateGenreService();
            var note = noteService.GetGenrebyId(id);
            return Ok(note);
        }
        public IHttpActionResult Put(GenreEdit note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateGenreService();
            if (!service.UpdateGenres(note))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();
            if (!service.DeleteGenre(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
