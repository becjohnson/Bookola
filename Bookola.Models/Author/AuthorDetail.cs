using Bookola.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Models
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        [Display(Name = "Author")]
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
