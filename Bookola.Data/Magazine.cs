using Newtonsoft.Json;
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
    public enum MagazineGenre { Womens, Music, Mens, Sports, Film, TvListing, Gossip, Beauty, News, Motor, Games, Hobbies, Computing, Consumer, Cultural, CurrentAffairs, Animals, GayInterest, Health, Technology, Children }

    public class Magazine
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTimeOffset IssueDate { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public MagazineGenre Genre { get; set; }
        public string FullName { get; set; }
        [ForeignKey("FullName")]
        public Author Author { get; set; }




    }
}
