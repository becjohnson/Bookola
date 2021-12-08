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
    public class MagazineListItem
    {
<<<<<<< HEAD
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
=======
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)
        [Required]
        public string Title { get; set; }
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
