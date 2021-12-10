using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public enum GraphicNovelGenre { Manga, SuperHeroStories, NonSuperHeroStories, PersonalNarratives, NonFiction}
    public class GraphicNovel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("LastName")]
        public Author Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public long Isbn { get; set; }
        
        [Required]
        public DateTime IssuedDate { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public GraphicNovelGenre GraphicNovelGenre { get; set; }
        
       
    }
}
