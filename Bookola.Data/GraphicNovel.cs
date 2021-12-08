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
        public long Isbn { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
        [Required]
        public string GenreName { get; set; }
        [ForeignKey("GenreName")]
        public Genre Genre { get; set; }
    }
}
