using System.ComponentModel.DataAnnotations;

namespace Bookola.Models.Author
{
    public class AuthorDetail
    {
        public int Id { get; set; }
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
    }
}
