using Bookola.Data;
using Bookola.Models;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    LastName = model.LastName
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
                                AuthorId = e.AuthorId,
                                FirstName = e.FirstName,
                                LastName = e.LastName
                            }
                        );
                return query.ToArray();
            }
        }

        public AuthorDetail GetAuthorbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == id && e.UserId == _userId);
                return

                    new AuthorDetail

                    {
                        AuthorId = entity.AuthorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                    };
            }
        }

        public AuthorDetail GetAuthorbyLastName(string lastName)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.LastName.Contains(lastName) && e.UserId == _userId);
                return

                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
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
                        .Single(e => e.AuthorId == model.AuthorId && e.UserId == _userId);
                
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId && e.UserId == _userId);
                ctx.Authors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

