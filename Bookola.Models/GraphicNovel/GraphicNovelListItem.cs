using Bookola.Data;
using System;
using System.Collections.Generic;

namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public GraphicNovelGenre Genre { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
