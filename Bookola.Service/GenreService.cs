using Bookola.Data;
using Bookola.Models.Genre;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Services.GenreService
{
    public class GenreService
    {
        private readonly Guid _userId;
        public GenreService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    UserId = _userId,
                    GenreName = model.GenreName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Genres
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new GenreListItem
                            {
                                GenreId = e.GenreId,
                                GenreName = e.GenreName,
                            }
                        );
                return query.ToArray();
            }
        }
        public GenreDetail GetGenrebyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == id && e.UserId == _userId);
                return
                    new GenreDetail
                    {
                        GenreId = entity.GenreId,
                        GenreName = entity.GenreName,
                    };
            }
        }
        public GenreDetail GetGenrebyName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreName.Contains(name) && e.UserId == _userId);
                return
                    new GenreDetail
                    {
                        GenreId = entity.GenreId,
                        GenreName = entity.GenreName,
                    };
            }
        }
        public bool UpdateGenres(GenreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == model.GenreId && e.UserId == _userId);
                entity.GenreName = model.GenreName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGenre(int GenreId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Genres
                        .Single(e => e.GenreId == GenreId && e.UserId == _userId);
                ctx.Genres.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}