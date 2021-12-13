using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelCreate
    {
        public string Title { get; set; }
        public long Isbn { get; set; }
        public int AuthorId { get; set; }
        public GraphicNovelGenre Genre { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
