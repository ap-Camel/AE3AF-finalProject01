using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    [Table("FavEpisodes")]
    public class FavEpisode
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int episode_id { get; set; }
        public string title { get; set; }
        public string season { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public string series { get; set; }
        public string imgUrl { get; set; }

    }
}
