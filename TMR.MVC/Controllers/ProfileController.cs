using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMR.Models;
using TMR.Services;

namespace TMR.MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult GetProfileSnapshot(Guid user)
        {
            var svc = CreateProfileService();
            var prof = svc.GetProfile(user);
            return View(prof);
        }

        //GET: SomeOne's Profile Detail
        public ActionResult GetProfileDetail(Guid user)
        {
            var svc = CreateProfileService();
            var prof = svc.GetProfile(user);
            return View(prof);
        }

        //GET: Set Profile
        public ActionResult MyProfile()
        {
            var svc = CreateProfileService();
            var prof = svc.GetMyProfile();
            
            return View(prof);
        }

        //GET: Set Profile
        public ActionResult SetProfile()
        {
            var svc = CreateProfileService();
            var prof = svc.GetMyProfile();
            return View(prof);
        }

        //POST: Set Profile 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetProfile(ProfileDetail model)
        {
            var svc = CreateProfileService();
            if (svc.SetProfile(model))
            {
                return RedirectToAction("MyProfile");
            }
            TempData["SaveResult"] = "There was an error changing your profile.";
            return RedirectToAction("SetProfile");
        }





        //SERVICE
        public ProfileService CreateProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userId);
            return service;
        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}