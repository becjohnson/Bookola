using Bookola.Data;
using Bookola.Models;
using Bookola.Models.Author;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Services
{
    public class AuthorService
    {
        private readonly Guid _userId;
        public AuthorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    UserId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
<<<<<<< HEAD
                    LastName = model.FirstName,
=======
>>>>>>> a5aabd4 (Added Author Controller)
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new AuthorListItem
                            {
<<<<<<< HEAD
                                Id = e.Id,
=======
>>>>>>> a5aabd4 (Added Author Controller)
                                FirstName = e.FirstName,
                                LastName = e.LastName
                            }
                        );
                return query.ToArray();
            }
        }
<<<<<<< HEAD

        public AuthorDetails GetAuthorbyId(int id)
        public AuthorDetail GetAuthorbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.Id == id && e.UserId == _userId);
                return

                    new AuthorDetails
                    new AuthorDetail

                    {
                        Id = entity.Id,
                        FullName = entity.FullName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                    };
            }
        }

        public AuthorDetails GetAuthorbyLastName(string lastName)
=======
        public IEnumerable<AuthorListItem> GetAuthorsbyName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Authors
                        .Where(e => e.FullName.Contains(name) && e.UserId == _userId)
                        .Select(
                                e =>
                    new AuthorListItem

                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                    }
                );
                return query.ToArray();
            }
        }
>>>>>>> a5aabd4 (Added Author Controller)
        public AuthorDetail GetAuthorbyLastName(string lastName)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.LastName.Contains(lastName) && e.UserId == _userId);
                return
<<<<<<< HEAD

                    new AuthorDetails
                    new AuthorDetail
                    {
                        Id = entity.Id,
=======
                    new AuthorDetail
                    {
>>>>>>> a5aabd4 (Added Author Controller)
                        FullName = entity.FullName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                    };
            }
        }
        public bool UpdateAuthors(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
<<<<<<< HEAD
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
=======
                        .Single(e => e.LastName == model.LastName && e.UserId == _userId);
>>>>>>> a5aabd4 (Added Author Controller)
                entity.FullName = model.FullName;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
<<<<<<< HEAD
        public bool DeleteAuthor(int noteId)
=======
        public bool DeleteAuthor(int id)
>>>>>>> a5aabd4 (Added Author Controller)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
<<<<<<< HEAD
                        .Single(e => e.Id == noteId && e.UserId == _userId);
=======
                        .Single(e => e.Id == id && e.UserId == _userId);
>>>>>>> a5aabd4 (Added Author Controller)
                ctx.Authors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

