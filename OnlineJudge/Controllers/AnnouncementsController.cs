﻿using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;
using OnlineJudge.FormModels;
using OnlineJudge.Repository;
using OnlineJudge.ResponseModels;

namespace OnlineJudge.Controllers{
    [RoutePrefix("api/announcements")]
    public class AnnouncementsController : ApiController{
        public AnnouncementRepository announcement_repository = new AnnouncementRepository();

        // todo add object not found exception handlers to acitons 
        public AnnouncementsController(): base(){
            
        }


        [HttpGet]
        [Route("")]
        public IHttpActionResult AnnouncementList(){
            return Ok(announcement_repository.GetAnnouncementList());
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult AnnouncementList(int from, int to){
            return Ok(announcement_repository.GetAnnouncementList(from, to));
        }


        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] AnnouncementFormData data){
            announcement_repository.createAnnouncement(data);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult AnnoucementDetails(int id){
            return Ok(announcement_repository.GetAnnouncementById(id));
        }

        [HttpPost]
        [Route("{id}/edit")]
        public IHttpActionResult EditAnnouncement(int id, [FromBody] AnnouncementFormData data){
            announcement_repository.UpdateAnnouncement(id, data);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/delete")]
        public IHttpActionResult DeleteAnnouncement(int id){
            try{
                announcement_repository.DeleteAnnouncement(id);
                return Ok();
            }
            catch (ObjectNotFoundException e){
                return NotFound();
            }
            
            
        }
        
    }
}
