
using System.ComponentModel.DataAnnotations;


namespace Bookola.Models.Author
{
    public class AuthorListItem
    {
        public int Id { get; set; }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
    }
}
