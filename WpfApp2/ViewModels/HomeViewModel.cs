using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Windows.Input;
using WpfApp2.Repositories;
using System.Threading;
using System.IO;

namespace WpfApp2.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<VideosModel> videos { get; set; }
        public string clickedVideoID { get; set; }
        private VideoDetailModel _videoDetail;

        public VideoDetailModel VideoDetail
        {
            get
            {
                return _videoDetail;
            }

            set
            {
                _videoDetail = value;
                OnPropertyChnaged(nameof(VideoDetail));
            }
        }


        public HomeViewModel()
        {
            VideoRepository repo = new VideoRepository();
            videos = repo.GetAll();

            var video = repo.GetByVideoId(clickedVideoID);
            if (video != null)
            {
                VideoDetail.Title = video.title;
                VideoDetail.Likes = video.likes;
                VideoDetail.Dislikes = video.dislikes;
                VideoDetail.Channel = video.channel;
                VideoDetail.ThumbnailURL = video.Thumbnail;
                Console.WriteLine(VideoDetail.Title);
            }
        }
    }
}
