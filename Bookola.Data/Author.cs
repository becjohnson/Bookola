using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
    public class Author
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Author")]
        public string FullName 
        {
            get => LastName + ", " + FirstName;
            set { }
        }
       
        
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
    }
}
