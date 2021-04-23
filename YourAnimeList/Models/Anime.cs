using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourAnimeList.Models
{
    public class Anime
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Anime Name")]
        [Required]
        public string AnimeName { get; set;}
        [DisplayName("Genre")]
        [Required]
        public string AnimeGenere { get; set; }
        [DisplayName("Description")]
        [Required]
        public string AnimeDescription { get; set; }
        [DisplayName("Release Date")]
        [Required]
        public string AnimeReleaseDate { get; set; }
        [DisplayName("Sudio")]
        [Required]
        public string AnimeStudio { get; set; }
        [DisplayName("Number of Episodes")]
        [Required]
        public int AnimeEpisodes { get; set; }
        [DisplayName("Ratings")]
        [Required]
        public float AnimeRating { get; set; }
        [DisplayName("Image Name.jpg")]
        [Required]
        public string AnimeURL { get; set; }
    }
}
