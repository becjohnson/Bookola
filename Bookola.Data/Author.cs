﻿using System;
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
        [Display(Name = "Author")]
        public string FullName
        {
            get => LastName + ", " + FirstName;
        }
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<GraphicNovel> GraphicNovels { get; set; }
    }
}