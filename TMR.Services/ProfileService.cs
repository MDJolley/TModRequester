using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;
using TMR.Models;

namespace TMR.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;
        public ProfileService(Guid id)
        {
            _userId = id;
        }
        //CREATE Profile
        public bool CreateProfile(Guid id)
        {
            using (var db = new ApplicationDbContext())
            {
                var prof = new Profile() { UserName = "Anonymous Terrarian", BIO = "No bio entered", Picture = Pictures.Guide, UserID = id };
                db.Profiles.Add(prof);
                return db.SaveChanges() == 1;
            }
        }

        //SET Profile
        public bool SetProfile(ProfileDetail profile)
        {
            var prof = new Profile();
            using (var db = new ApplicationDbContext())
            {
                prof = db.Profiles.Single(p => p.UserID == _userId);
                prof.Picture = profile.Picture;
                prof.UserName = profile.UserName;
                prof.BIO = profile.BIO;
                return db.SaveChanges() == 1;
            }
        }
        public ProfileDetail GetMyProfile()
        {
            using (var db = new ApplicationDbContext())
            {
                var check = db.Profiles.SingleOrDefault(p => p.UserID == _userId);
                if (check == null)
                {
                    CreateProfile(_userId);
                }
                    var entity = db.Profiles.SingleOrDefault(p => p.UserID == _userId);
                var prof = new ProfileDetail { BIO = entity.BIO, Picture = entity.Picture, UserName = entity.UserName };
                return prof;
            }
        }

        public ProfileDetail GetProfile(Guid user)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Profiles.Single(p => p.UserID == user);
                var prof = new ProfileDetail { BIO = entity.BIO, Picture = entity.Picture, UserName = entity.UserName };
                return prof;
            }
        }

        //Write a method that converts a collection of profiles to profile details



    }
}
