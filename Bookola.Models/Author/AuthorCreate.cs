using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Author
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
        
    }
}
