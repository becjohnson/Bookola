using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName 
        {
            get => LastName + ", " + FirstName;
            set { }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
    }
}
