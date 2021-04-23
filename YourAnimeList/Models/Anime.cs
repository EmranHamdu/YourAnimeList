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
        public string AnimeName { get; set;}
        [DisplayName("Genre")]
        public string AnimeGenere { get; set; }
        [DisplayName("Description")]
        public string AnimeDescription { get; set; }
        [DisplayName("Release Date")]
        public string AnimeReleaseDate { get; set; }
        [DisplayName("Sudio")]
        public string AnimeStudio { get; set; }
        [DisplayName("Number of Episodes")]
        public int AnimeEpisodes { get; set; }
        [DisplayName("Ratings")]
        public float AnimeRating { get; set; }
        [DisplayName("Image Name.jpg")]
        public string AnimeURL { get; set; }
    }
}
