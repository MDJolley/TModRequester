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
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult Index()
        {
            return View();
        }

        //GET: Replies/post
        public ActionResult GetRepliesByPost(int postID)
        {
            var svc = CreateReplyService();
            var model = svc.GetRepliesByPost(postID);
            var profileList = new List<ProfileDetail>();
            foreach (var item in model)
            {
                using (var prof = new TMR.MVC.Controllers.ProfileController())
                {
                    var profService = prof.CreateProfileService();
                     profileList.Add(profService.GetProfile(item.UserID));
                }
            }
            ViewBag.ListOfProfiles = profileList;
            return PartialView(model);
        }

        //GET: Reply/create
        public ActionResult CreateReply()
        {
            return View();
        }

        //POST: Reply/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReply(ReplyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReplyService();

            if (service.CreateReply(model))
            {
                TempData["SaveResult"] = "Your reply was successfully uploaded.";
                return RedirectToAction($"../Post/Details/{model.PostID}");
            };
            return View(model);
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            var svc = CreateReplyService();
            var model = svc.GetReplyByID(id);
            return View(model);
        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ReplyDetail model)
        {
            var svc = CreateReplyService();
            var reply = svc.GetReplyByID(id);
            int postId = reply.PostID;
            svc.DeleteReply(model.ID);
            return RedirectToAction($"../Post/Details/{postId}");
        }






        //SERVICE
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            return service;
        }
    }
}