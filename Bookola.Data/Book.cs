using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Book
    {
<<<<<<< HEAD
        [Key]
=======
>>>>>>> a5aabd4 (Added Author Controller)
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
<<<<<<< HEAD
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
=======
        [Key]
        public string Title { get; set; }
        public string LastName { get; set; }
        [ForeignKey("LastName"), Display(Name = "Author")]
        public Author Author { get; set; }
        public string GenreName { get; set; }
        [ForeignKey("GenreName")]
        public Genre Genre { get; set; }
        public int CountryCode { get; set; }
        public int ReadingLevel { get; set; }
        public long Isbn { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)
    }
}
