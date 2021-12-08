using Bookola.Data;
using Bookola.Models.Book;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Services
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
                    LastName = model.LastName,
                    Isbn = model.Isbn,
                    CountryCode = model.CountryCode,
                    ReadingLevel = model.ReadingLevel,
                    GenreName = model.GenreName
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
                                Id = e.Id,
                                Title = e.Title,
                                LastName = e.LastName,
                                GenreName = e.GenreName
                            }
                        );
                return query.ToArray();
            }
        }
        public BookDetail GetBookbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName,
                    };
            }
        }
        public BookDetail GetBookbyTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Title.Contains(title) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName
                    };
            }
        }
        public BookDetail GetBookbyLastName(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.LastName.Contains(author) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                    };
            }
        }
        public BookDetail GetBookbyIsbn(long isbn)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Isbn == isbn && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName
                    };
            }
        }
        public BookDetail GetBookbyCountryCode(int countryCode)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.CountryCode == countryCode && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName
                    };
            }
        }
        public BookDetail GetBookbyReadingLevel(int readingLevel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.ReadingLevel == readingLevel && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName
                    };
            }
        }
        public BookDetail GetBookbyGenre(string genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.GenreName.Contains(genre) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        LastName = entity.LastName,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                        GenreName = entity.GenreName
                    };
            }
        }
        public bool UpdateBooks(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.LastName = model.LastName;
                entity.Isbn = model.Isbn;
                entity.CountryCode = model.CountryCode;
                entity.GenreName = model.GenreName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Id == id && e.UserId == _userId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}