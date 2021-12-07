using System.ComponentModel.DataAnnotations;

namespace Bookola.Models
{
    public class GenreCreate
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
