using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;
using TMR.Models;

namespace TMR.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid id)
        {
            _userId = id;
        }

        //CREATE
        public bool CreateReply(ReplyCreate model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Profiles.SingleOrDefault(p => p.UserID == _userId) == null)
                {
                    var svc = new ProfileService(_userId);
                    svc.CreateProfile(_userId);
                }
                var entity = new Reply()
                {
                    UserID = _userId,
                    Body = model.Body,
                    TimePosted = DateTimeOffset.Now,
                    PostID = model.PostID,
                };
                db.Replies.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        //GET BY USER
        public IEnumerable<ReplyListItem> GetRepliesByUser()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Replies.Where(e => e.UserID == _userId).Select(e => new ReplyListItem
                {
                    ID = e.ID,
                    UserID = e.UserID,
                    ProfileDetail = new ProfileDetail() { BIO=e.Profile.BIO, Picture=e.Profile.Picture, UserName=e.Profile.UserName},
                    Body = e.Body,
                    PostID = e.PostID
                });
                return query.ToArray();
            }
        }

        //GET BY REPLY ID
        public ReplyDetail GetReplyByID(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Replies.Single(e => e.ID == id);
                return new ReplyDetail
                {
                    ID = entity.ID,
                    UserID = entity.UserID,
                    Body = entity.Body,
                    TimePosted = entity.TimePosted,
                    TimeEdited = entity.TimeEdited,
                    Solution = entity.Solution,
                    PostID = entity.PostID,
                    ProfileDetail = new ProfileDetail() { BIO = entity.Profile.BIO, Picture = entity.Profile.Picture, UserName = entity.Profile.UserName }
                };
            }
        }

        //GET BY POST ID
        public IEnumerable<ReplyListItem> GetRepliesByPost(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Replies.Where(e => e.PostID == id).Select(e => new ReplyListItem
                {
                    ID = e.ID,
                    UserID = e.UserID,
                    ProfileDetail = new ProfileDetail() { BIO = e.Profile.BIO, Picture = e.Profile.Picture, UserName = e.Profile.UserName },
                    Body = e.Body,
                    PostID = e.PostID
                });
                //Trying a new way to create a viewbag

                var profiles = new List<ProfileDetail>();
                var prof = new ProfileService(_userId);
                foreach (var item in query)
                {

                    {
                        profiles.Add(prof.GetProfile(item.UserID));
                    }
                }
                
                return query.ToArray();
            }
        }

        //EDIT REPLY
        public bool EditReply(ReplyEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Replies.Single(e => e.ID == model.ID && e.UserID == _userId);
                entity.Body = model.Body;
                entity.TimeEdited = DateTimeOffset.Now;

                return db.SaveChanges() == 1;
            }
        }

        //DELETE REPLY
        public bool DeleteReply(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Replies.Single(e => e.ID == id && e.UserID == _userId);
                db.Replies.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }







    }
}
