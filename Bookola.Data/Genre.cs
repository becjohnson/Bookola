using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
   
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
       
        [Required]
        public string Name { get; set; }
    }
}