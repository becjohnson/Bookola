using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Book
{
    public class BookListItem
    {
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Key]
        public string Title { get; set; }
        [ForeignKey("LastName"), Display(Name = "Author")]
        public string LastName { get; set; }
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
