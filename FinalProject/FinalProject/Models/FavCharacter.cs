using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace FinalProject.Models
{
    [Table("FavCharacters")]
    public class FavCharacter
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int char_id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string img { get; set; }
        public string status { get; set; }
        public string nickname { get; set; }
        public string portrayed { get; set; }

    }
}
