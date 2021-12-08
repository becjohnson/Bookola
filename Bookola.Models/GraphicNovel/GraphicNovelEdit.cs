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
    public class GraphicNovelEdit
    {
        public int Id { get; set; }
        [Key]
        [Required]
        public string Title { get; set; }
        [Required, ForeignKey("LastName"), Display(Name = "Author")]
        public string LastName { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
        [Required]
        [ForeignKey("GenreName")]
        public string GenreName { get; set; }
    }
}
