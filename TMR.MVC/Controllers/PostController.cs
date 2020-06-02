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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var profService = new ProfileService(userId);
            var model = service.GetPosts();
            ViewBag.Viewer = userId;
            foreach(var item in model)
            {
                ViewBag.Profile = profService.GetProfile(userId);
            }

            return View(model);
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your post was successfully uploaded.";
                return RedirectToAction("Index");
            };
            return View(model);
        }

        //GET: DETAILS post/{id}
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostByID(id); //check this

            //POST: Reply:: ViewBag
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            var profService = new ProfileService(userId);
            ViewBag.PostID = id;
            ViewBag.PosterID = model.UserID;
            ViewBag.Profile = profService.GetProfile(userId); // check this

            //GET: Replies:: ViewBag
            var replyList = replyService.GetRepliesByPost(id);
            ViewBag.ReplyList = replyList;
            
            return View(model);
        }



        //GET: post/edit{id}
        public ActionResult Edit(int id)
        {
            var svc = CreatePostService();
            var detail = svc.GetPostByID(id);
            var model = new PostEdit
            {
                ID = detail.ID,
                Title = detail.Title,
                Body = detail.Body
            };
            return View(model);
        }
        //POST EDIT
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var svc = CreatePostService();
            if (svc.EditPost(model))
            {
                TempData["SaveResult"] = "Your post was successfully edited.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //GET delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var post = svc.GetPostByID(id);
            return View(post);
        }

        //POST delete/{id}
        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PostDetail model)
        {
            if (!ModelState.IsValid) return View(model);
            var svc = CreatePostService();

            
            if (svc.DeletePost(id))
            {
                TempData["SaveResult"] = "Your post was successfully deleted.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
         //GET details/{id} Vote
         public ActionResult Vote()
        {
            return View();
        }

        //POST details/{id} VOTE
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            var svc = CreatePostService();
            if (svc.VotePost(id))
            {
                return RedirectToAction($"Details/{id}");
            }
            TempData["SaveResult"] = "Unable to change your vote.";
            return RedirectToAction($"Details/{id}");
        }



        //SERVICE
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}