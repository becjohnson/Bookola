using System.ComponentModel.DataAnnotations;

namespace Bookola.Models.Genre
{
    public class GenreEdit
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
