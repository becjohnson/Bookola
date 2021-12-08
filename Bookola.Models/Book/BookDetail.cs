using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> a5aabd4 (Added Author Controller)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Book
{
    public class BookDetail
    {
<<<<<<< HEAD
=======
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Key]
        public string Title { get; set; }
        public string LastName { get; set; }
        [ForeignKey("LastName"), Display(Name = "Author")]
        public string GenreName { get; set; }
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public int CountryCode { get; set; }
        public int ReadingLevel { get; set; }
        public long Isbn { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)
    }
}
