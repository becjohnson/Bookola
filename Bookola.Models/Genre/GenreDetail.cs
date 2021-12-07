using System.ComponentModel.DataAnnotations;

namespace Bookola.Models.Genre
{
    public class GenreDetail
    {
        public int Id
        {
            get; set;
        }
        [Display(Name = "Genre")]
        public string GenreName
        {
            get; set;
        }
    }
}
