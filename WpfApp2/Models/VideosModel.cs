using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class VideosModel
    {
        public string ID { get; set; }
        public string Thumbnail { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public string title { get; set; }
        public string channel { get; set; }
    }
}
