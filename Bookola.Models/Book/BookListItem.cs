﻿using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models
{
    public class BookListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Author")]
        public ICollection<Author> Authors { get; set; }
        public int AuthorId { get; set; }
    }
}
