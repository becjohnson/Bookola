using Bookola.Data;
using Bookola.Models.Magazine;
using Bookola.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Service
{
    public class MagazineService
    {
        private readonly Guid _userId;

        public MagazineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMagazine(MagazineCreate model)
        {
            var entity = new Magazine
            {
                UserId = _userId,
                Title = model.Title,
                LastName = model.LastName,
                Volume = model.Volume,
                IssueDate = model.IssueDate,
                GenreName = model.GenreName,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Magazines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MagazineListItem> GetMagazines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Magazines
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new MagazineListItem
                        {
                            Id = e.Id,
                            LastName = e.LastName,
                            Title = e.Title
                        });
                return query.ToArray();
            }
        }

        public object GetMagazineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Magazines
                    .Where(e => e.Id == id && e.UserId == _userId)
                    .Select(
                        e =>
                        new MagazineListItem
                        {
                            Id = e.Id,
                            LastName = e.LastName,
                            Title = e.Title
                        });
                return query.ToArray();
            }
        }

        public bool UpdateMagazines(MagazineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Title = model.Title;
                entity.LastName = model.LastName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMagazine(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Magazines
                        .Single(e => e.Id == Id && e.UserId == _userId);
                ctx.Magazines.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
    

