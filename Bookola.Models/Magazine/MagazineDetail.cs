using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Magazine
{
    public class MagazineDetail
    {
<<<<<<< HEAD
        [Key]
=======
>>>>>>> a5aabd4 (Added Author Controller)
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
<<<<<<< HEAD
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
=======
        public string LastName { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)
        [Required]
        public int Volume { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
<<<<<<< HEAD

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
=======
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public string GenreName { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)

    }
}
