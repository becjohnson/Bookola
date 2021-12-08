using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Genre
{
    public class GenreDetail
    {
        public int GenreId { get; set; }
        [Required]
        [Key]
        public string GenreName { get; set; }
    }
}
