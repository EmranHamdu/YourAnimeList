using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourAnimeList.Models
{
    public class Anime
    {
        [Key]
        public int ID { get; set; }

        public string AnimeName { get; set;}

        public string AnimeGenere { get; set; }

        public string AnimeDescription { get; set; }

        public string AnimeReleaseDate { get; set; }
        
        public string AnimeStudio { get; set; }

        public int AnimeEpisodes { get; set; }

        public float AnimeRating { get; set; }
        public string AnimeURL { get; set; }
    }
}
