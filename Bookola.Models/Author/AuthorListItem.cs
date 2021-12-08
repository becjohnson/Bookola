using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> a5aabd4 (Added Author Controller)

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
