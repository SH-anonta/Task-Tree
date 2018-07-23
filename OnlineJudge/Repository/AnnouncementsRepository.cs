﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineJudge.FormModels;
using OnlineJudge.Models;
using OnlineJudge.ResponseModels;

namespace OnlineJudge.Repository {
    public partial class DataRepository {
        // returns the n most recent announcements
        public static void GetRecentAnnouncements(int n = 20){
            //todo implement

        }

        public static List<AnnouncementsResponseData> GetAllAnnouncements(){
            var ctx = getContext();
            return AnnouncementsResponseData.MapTo(ctx.Announcements);
        }

        public static void createAnnouncement(AnnouncementForm data){
            var ctx = getContext();
            Announcement announcement = new Announcement(){
                Title = data.Title,
                Description = data.Description,
                CreateDate = DateTime.Now,
                Creator = ctx.Users.First(x => x.UserName == "admin")
            };

            ctx.Announcements.Add(announcement);
            ctx.SaveChanges();
        }
    }
}