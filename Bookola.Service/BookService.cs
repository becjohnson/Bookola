<<<<<<< HEAD
﻿using System;
=======
﻿using Bookola.Data;
using Bookola.Models.Book;
using Bookola.WebAPI.Models;
using System;
>>>>>>> a5aabd4 (Added Author Controller)
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Bookola.Service
{
    public class BookService
    {
<<<<<<< Updated upstream
=======
=======
namespace Bookola.Services
{
    public class BookService
    {
>>>>>>> a5aabd4 (Added Author Controller)
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
<<<<<<< HEAD
                    FullName = model.FullName,
                    CountryCode = model.CountryCode,
                    ReadingLevel = model.ReadingLevel,
                    GenreName = model.GenreName,
=======
                    LastName = model.LastName,
                    Isbn = model.Isbn,
                    CountryCode = model.CountryCode,
                    ReadingLevel = model.ReadingLevel,
                    GenreName = model.GenreName
>>>>>>> a5aabd4 (Added Author Controller)
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
<<<<<<< HEAD
                                Title = e.Title,
                                
=======
                                Id = e.Id,
                                Title = e.Title,
                                LastName = e.LastName,
                                GenreName = e.GenreName
>>>>>>> a5aabd4 (Added Author Controller)
                            }
                        );
                return query.ToArray();
            }
        }
<<<<<<< HEAD
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
        public IEnumerable<BookListItem> GetBookByAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Books
                    .Where(e => e.FullName.Contains(author) && e.UserId == _userId)
                    .Select(
                        e =>
                            new BookListItem
                            {
                                Title = e.Title,
                                FullName = e.Title,
                            }
                        );
                return query.ToArray();
=======
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
>>>>>>> a5aabd4 (Added Author Controller)
            }
        }
        public bool UpdateBooks(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
<<<<<<< HEAD
                        .Single(e => e.Title == model.Title && e.UserId == _userId);
                entity.Title = model.Title;
                entity.FullName = model.FullName;
                entity.CountryCode = model.CountryCode;
=======
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.LastName = model.LastName;
                entity.Isbn = model.Isbn;
                entity.CountryCode = model.CountryCode;
                entity.GenreName = model.GenreName;
>>>>>>> a5aabd4 (Added Author Controller)

                return ctx.SaveChanges() == 1;
            }
        }
<<<<<<< HEAD
        public bool DeleteBook(string title)
=======
        public bool DeleteBook(int id)
>>>>>>> a5aabd4 (Added Author Controller)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
<<<<<<< HEAD
                        .Single(e => e.Title == title && e.UserId == _userId);
=======
                        .Single(e => e.Id == id && e.UserId == _userId);
>>>>>>> a5aabd4 (Added Author Controller)
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
<<<<<<< HEAD
>>>>>>> Stashed changes
    }
}
=======
    }
}
>>>>>>> a5aabd4 (Added Author Controller)
