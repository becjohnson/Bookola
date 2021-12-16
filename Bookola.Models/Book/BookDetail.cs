using Bookola.Data;

namespace Bookola.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public long Isbn { get; set; }
        public BookGenre Genre { get; set; }
    }
}
