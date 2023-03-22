using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public  interface IVideosRepository
    {
        List<VideosModel> GetAll();
        VideosModel GetByVideoId(string videoId);
    }
}
