using Bookola.Data;
using Bookola.Models;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //var author = new Author();
            var entity =
                new Book()
                {
                    UserId = _userId,
                    Title = model.Title,
                    Isbn = model.Isbn,
                    AuthorId = model.AuthorId
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
                                Authors = e.Authors,
                                AuthorId = e.AuthorId
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
                        Authors = entity.Authors,
                        Isbn = entity.Isbn,
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
                        Authors = entity.Authors,
                        Isbn = entity.Isbn,
                    };
            }
        }
       /* public BookDetail GetBookbyAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.Author.Contains(author) && e.UserId == _userId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        AuthorId = entity.AuthorId,
                        Isbn = entity.Isbn,
                        CountryCode = entity.CountryCode,
                        ReadingLevel = entity.ReadingLevel,
                    };
            }
        }*/
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
                        Authors = entity.Authors,
                        Isbn = entity.Isbn,
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
                entity.Authors = model.Authors;
                entity.Isbn = model.Isbn;

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