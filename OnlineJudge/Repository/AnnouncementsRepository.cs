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

        public static List<AnnouncementListItem> GetAnnouncementList(){
            var ctx = getContext();
            return AnnouncementListItem.MapTo(ctx.Announcements);
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

        public static AnnouncementsResponseData GetAnnouncementById(int id){
            var announcement = getContext().Announcements.Find(id);
            return new AnnouncementsResponseData(announcement);
        }
    }
}