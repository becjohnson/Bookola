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
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorId { get; set; }

        [Required]
        public int Volume { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

    }
}
