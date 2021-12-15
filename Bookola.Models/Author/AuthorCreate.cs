
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Bookola.Models
{
    public class AuthorCreate
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<Book> Books { get; set; }
    }
}
