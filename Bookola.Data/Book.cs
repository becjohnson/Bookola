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
    public enum BookGenre { Action, Adventure, Classic, Mystery, Fantasy, History, Horror, Fiction, Audio, Childrens, Romance, SciFi, ShortStories, Suspense, Thriller, Biography, Autobiography, Cookbooks, Essays, Poems, Memoir, SelfHelp, TrueCrime}
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        public int CountryCode { get; set; }
        [Required]
        public int ReadingLevel { get; set; }
        [Required]
        
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public BookGenre Genre { get; set; }
    }
}
