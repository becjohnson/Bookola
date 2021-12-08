using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> a5aabd4 (Added Author Controller)

namespace Bookola.Models
{
    public class AuthorCreate
    {
        public int Id { get; set; }
        [Display(Name = "Author")]
<<<<<<< HEAD
        public string FullName
        {
            get => LastName + ", " + FirstName;
        }
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
=======
        [Key]
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
>>>>>>> a5aabd4 (Added Author Controller)
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
    }
}
