using Bookola.Data;
using Bookola.Models.Book;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubola.Services
{
    public class BookService
    {
        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    UserId = _userId,
                    Title = model.Title,
                    FullName = model.FullName,
                    Isbn = model.Isbn,
                    CountryCode = model.CountryCode,
                    ReadingLevel = model.ReadingLevel,
                    GenreName = model.GenreName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Title = e.Title,
                                
                            }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<BookListItem> GetBookByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.Title == title && e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Title = e.Title,

                            }
                        );
                return query.ToArray();
            }
        }
        public bool UpdateBooks(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Title == model.Title && e.UserId == _userId);
                entity.Title = model.Title;
                entity.FullName = model.FullName;
                entity.Isbn = model.Isbn;
                entity.CountryCode = model.CountryCode;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Title == title && e.UserId == _userId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
