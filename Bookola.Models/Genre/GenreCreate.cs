using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models
{
    public class GenreCreate
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
