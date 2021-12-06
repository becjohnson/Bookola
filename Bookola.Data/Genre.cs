using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [Key]
        public string GenreName { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}