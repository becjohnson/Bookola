using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Magazine
    {
<<<<<<< HEAD
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        [ForeignKey("FullName")]
        public Author Author { get; set; }


        [Required]
        public Guid UserId { get; set; }
        public int Countrycode { get; set; }
        public int ReadingLevel { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Volume { get; set; }
        
        [Required]
        public DateTime IssueDate { get; set; }
        public int ISSN { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
=======
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }   
        [Key]
        [Required]
        public string Title { get; set; }
        [Required]        
        public int Volume { get; set; }
        [Required]
        public string LastName { get; set; }
        [ForeignKey("LastName"), Display(Name = "Author")]
        public Author Author { get; set; }
        public int Countrycode { get; set; }
        public int ReadingLevel { get; set; }
        
        [Required, Display(Name = "Issue Date"), DisplayFormat(DataFormatString = "MM-DD-YYYY", ApplyFormatInEditMode = true)]
        public DateTime IssueDate { get; set; }
        public int ISSN { get; set; }
        public string GenreName { get; set; }

        [ForeignKey("GenreName")]
>>>>>>> a5aabd4 (Added Author Controller)
        public Genre Genre { get; set; }

    }
}
