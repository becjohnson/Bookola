using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookola.Data;

namespace Bookola.Models
{
    public class BookCreate
    {
        public string Title { get; set; }
        public long Isbn { get; set; }
        public int AuthorId { get; set; }
    }
}
