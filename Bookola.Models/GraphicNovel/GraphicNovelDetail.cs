using Bookola.Data;
using System;
using System.Collections.Generic;
namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Isbn { get; set; }
        public int Volume { get; set; }
        public int AuthorId { get; set; }
        public DateTimeOffset IssuedDate { get; set; }
        public GraphicNovelGenre Genre { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
