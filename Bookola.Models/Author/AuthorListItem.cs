
using System.ComponentModel.DataAnnotations;


namespace Bookola.Models
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
    }
}
