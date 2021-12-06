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
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Key]
        public string Title { get; set; }
        [Required]
        public string FullName { get; set; }
        [ForeignKey("FullName")]
        [Display(Name = "Author")]
        public Author Author { get; set; }
        [Display(Name = "ISBN")]
        public long Isbn { get; set; }
        [Display(Name = "Country Code")]
        public int CountryCode { get; set; }
        [Display(Name = "Reading Level")]
        public int ReadingLevel { get; set; }
        [Required]
        public string GenreName { get; set; }
        [ForeignKey("GenreName")]
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }
    }
}
