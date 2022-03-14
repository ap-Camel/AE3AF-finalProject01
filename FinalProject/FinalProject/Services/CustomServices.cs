using FinalProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FinalProject.Services
{
    public class CustomServices
    {

        public static List<Season> GetSeasons()
        {
            List<Season> seasons = new List<Season>();

            Season season1 = new Season();
            Season season2 = new Season();
            Season season3 = new Season();
            Season season4 = new Season();
            Season season5 = new Season();

            season1.id = "1";
            season1.name = "Season 1";
            season1.imgUrl = "https://static.wikia.nocookie.net/breakingbad/images/5/58/BB_S1_poster.jpg/revision/latest/scale-to-width-down/560?cb=20170524134743";
            seasons.Add(season1);

            season2.id = "2";
            season2.name = "Season 2";
            season2.imgUrl = "https://static.wikia.nocookie.net/breakingbad/images/0/00/BB_S2_poster.jpg/revision/latest/scale-to-width-down/560?cb=20170524134840";
            seasons.Add(season2);

            season3.id = "3";
            season3.name = "Season 3";
            season3.imgUrl = "https://static.wikia.nocookie.net/breakingbad/images/c/c7/BB_S3_poster.jpg/revision/latest/scale-to-width-down/560?cb=20170524134929";
            seasons.Add(season3);

            season4.id = "4";
            season4.name = "Season 4";
            season4.imgUrl = "https://static.wikia.nocookie.net/breakingbad/images/9/95/BB_S4_poster.jpg/revision/latest/scale-to-width-down/560?cb=20170524135147";
            seasons.Add(season4);

            season5.id = "5";
            season5.name = "Season 5";
            season5.imgUrl = "https://static.wikia.nocookie.net/breakingbad/images/d/d3/BB_S5A_poster.jpg/revision/latest/scale-to-width-down/560?cb=20170524135652";
            seasons.Add(season5);

            return seasons;
        }

    }
}
