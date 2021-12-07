using System.ComponentModel.DataAnnotations;

namespace Bookola.Models.Book
{
    public class BookEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Author")]
        public string FullName { get; set; }
        [Display(Name = "ISBN")]
        public long Isbn { get; set; }
        [Display(Name = "Country Code")]
        public int CountryCode { get; set; }
        [Display(Name = "Reading Level")]
        public int ReadingLevel { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
