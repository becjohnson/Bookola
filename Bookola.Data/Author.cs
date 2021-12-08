using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Author
    {
        public int Id { get; set; }
        [Key, Required, Display(Name = "First"), MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last"), MaxLength(50)]
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = " ")]
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
        public string GenreName { get; set; }
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public Genre Genre { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
    }
}
