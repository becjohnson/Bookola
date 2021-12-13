﻿using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Magazine
{
    public class MagazineDetail
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTimeOffset IssueDate { get; set; }
        public MagazineGenre Genre { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
