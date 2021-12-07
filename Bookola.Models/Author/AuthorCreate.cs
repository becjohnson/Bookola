using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Models
{
    public class AuthorCreate
    {
        public int Id { get; set; }
        [Display(Name = "Author")]
        public string FullName
        {
            get => LastName + ", " + FirstName;
        }
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
