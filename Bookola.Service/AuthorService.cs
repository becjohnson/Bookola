using Bookola.Data;
using Bookola.Models.Author;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Service
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
                                Id = e.Id,
                                FirstName = e.FirstName,
                                LastName = e.LastName
                            }
                        );
                return query.ToArray();
            }
        }
        public AuthorDetails GetAuthorbyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new AuthorDetails
                    {
                        Id = entity.Id,
                        FullName = entity.FullName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                    };
            }
        }
        public AuthorDetails GetAuthorbyLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.LastName.Contains(lastName) && e.UserId == _userId);
                return
                    new AuthorDetails
                    {
                        Id = entity.Id,
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
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.FullName = model.FullName;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAuthor(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.Id == noteId && e.UserId == _userId);
                ctx.Authors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
