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
    public class GraphicNovelDetail
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
       
      
    }
}
