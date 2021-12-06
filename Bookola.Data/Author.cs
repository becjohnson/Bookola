using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Author
    {
        public int Id { get; set; }
        [Key]
        public string FullName 
        {
            get => LastName + ", " + FirstName;
        }
        [Display(Name = "Author")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
