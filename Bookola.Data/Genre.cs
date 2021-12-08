using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
   
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        [Key]
        public string GenreName { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}