
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class Character
    {

        public int char_id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public List<string> occupation { get; set; }
        public string img { get; set; }
        public string status { get; set; }
        public string nickname { get; set; }
        public List<int> appearance { get; set; }
        public string portrayed { get; set; }

    }
}
