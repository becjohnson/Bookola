using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models
{
    public class AuthorCreate
    {
        public int Id { get; set; }
        [Display(Name = "Author")]
        [Key]
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
    }
}
