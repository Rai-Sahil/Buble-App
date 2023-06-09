﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp2.Models;
using WpfApp2.Repositories;

namespace WpfApp2.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {

        public List<UserModel> customers { get; set; }
        UserRepository userRepository;

        public CustomerViewModel()
        {
            userRepository = new UserRepository();
            customers = userRepository.GetByAll();

            //var video = repo.GetByVideoId(clickedVideoID);
            //if (video != null)
            //{
            //    VideoDetail.Title = video.title;
            //    VideoDetail.Likes = video.likes;
            //    VideoDetail.Dislikes = video.dislikes;
            //    VideoDetail.Channel = video.channel;
            //    VideoDetail.ThumbnailURL = video.Thumbnail;
            //}
        }

        public void update_followings_and_followers(string Uid)
        {
            userRepository.addFollowing(Thread.CurrentPrincipal.Identity.Name, Uid);
            userRepository.addFollower(Uid, Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
