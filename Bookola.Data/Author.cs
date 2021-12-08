using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> a5aabd4 (Added Author Controller)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Author
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public Guid UserId { get; set; }
        [Display(Name = "Author")]
        public string FullName 
        {
            get => LastName + ", " + FirstName;
            set { }
        [Display(Name = "Author")]
=======
        [Key, Required, Display(Name = "First"), MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last"), MaxLength(50)]
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = " ")]
>>>>>>> a5aabd4 (Added Author Controller)
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
<<<<<<< HEAD
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
=======
        public string GenreName { get; set; }
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public Genre Genre { get; set; }
>>>>>>> a5aabd4 (Added Author Controller)
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
    }
}
