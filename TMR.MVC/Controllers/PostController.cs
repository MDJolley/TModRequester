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
            var model = new PostListItem[0];

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





        //SERVICE
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}