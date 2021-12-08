﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Book
{
    public class BookEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Isbn { get; set; }
        public int CountryCode { get; set; }
        public int ReadingLevel { get; set; }
        public int GenreId { get; set; }
    }
}
