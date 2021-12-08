using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class GraphicNovel
    {
<<<<<<< HEAD
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        [ForeignKey("FullName")]
        public Author Author { get; set; }



        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; set; }

        [Required]
=======
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string LastName { get; set; }
        [ForeignKey("LastName"), Display(Name = "Author")]
        public Author Author { get; set; }
        [Key]
        [Required]
        public string Title { get; set; }
        [Required]
>>>>>>> a5aabd4 (Added Author Controller)
        public long Isbn { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
        [Required]
<<<<<<< HEAD
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
=======
        public string GenreName { get; set; }
        [ForeignKey("GenreName")]
>>>>>>> a5aabd4 (Added Author Controller)
        public Genre Genre { get; set; }
    }
}
