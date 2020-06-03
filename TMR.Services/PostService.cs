using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;
using TMR.Models;

namespace TMR.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid id)
        {
            _userId = id;
        }

        //CREATE
        public bool CreatePost(PostCreate model)
        {
            using (var db = new ApplicationDbContext())
            {
                var userProfile = db.Profiles.SingleOrDefault(p => p.UserID == _userId);
                if (userProfile==null)
                {
                    var svc = new ProfileService(_userId);
                    svc.CreateProfile(_userId);
                }
                var entity = new Post()
                {
                    UserID = _userId,
                    Title = model.Title,
                    Body = model.Body,
                    TimePosted = DateTimeOffset.Now,
                    Profile = db.Profiles.Single(p => p.UserID == _userId)
                };


                db.Posts.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Posts.Select(e => new PostListItem
                {
                    PostID = e.ID,
                    Title = e.Title,
                    TimePosted = e.TimePosted,
                    Votes = e.Votes,
                    Profile = new ProfileDetail()
                    {
                        BIO = e.Profile.BIO,
                        Picture = e.Profile.Picture,
                        UserName = e.Profile.UserName
                    }
                });
                return query.ToArray();
            }
        }

        //GET BY USER
        public IEnumerable<PostListItem> GetPostsByUser(Guid user)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Posts.Where(e => e.UserID == user).Select(e => new PostListItem
                {
                    PostID = e.ID,
                    Title = e.Title,
                    TimePosted = e.TimePosted,
                    Votes = e.Votes,
                    UserID = e.UserID,
                    Profile = new ProfileDetail()
                    {
                        BIO = e.Profile.BIO,
                        Picture = e.Profile.Picture,
                        UserName = e.Profile.UserName
                    }

                });
                return query.ToArray();
            }
        }

        //GET BY POST ID
        public PostDetail GetPostByID(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts.Single(e => e.ID == id);
                return new PostDetail
                {
                    ID = entity.ID,
                    UserID = entity.UserID,
                    Title = entity.Title,
                    Body = entity.Body,
                    TimePosted = entity.TimePosted,
                    TimeEdited = entity.TimeEdited,
                    Voters = entity.Voters,
                    Votes = entity.Votes,
                    Solved = entity.Solved,
                    Profile = new ProfileDetail()
                    {
                        BIO = entity.Profile.BIO,
                        Picture = entity.Profile.Picture,
                        UserName = entity.Profile.UserName
                    }
                };
            }
        }

        //EDIT POST
        public bool EditPost(PostEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts.Single(e => e.ID == model.ID && e.UserID == _userId);
                entity.Title = model.Title;
                entity.Body = model.Body;
                entity.TimeEdited = DateTimeOffset.Now;

                return db.SaveChanges() == 1;
            }
        }

        //DELETE POST BY ID
        public bool DeletePost(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts.Single(e => e.ID == id && e.UserID == _userId);
                db.Posts.Remove(entity);
                return db.SaveChanges() == 1;
            }
        }

        //VOTE FOR POST (OR UNVOTE)
        public bool VotePost(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var post = db.Posts.Single(p => p.ID == id);
                if (post.Voters.Contains(_userId))
                {
                    post.Voters.Remove(_userId);
                    post.Votes--;
                    return db.SaveChanges() == 1;
                }
                if (!post.Voters.Contains(_userId))
                {
                    post.Voters.Add(_userId);
                    post.Votes++;
                    return db.SaveChanges() == 1;
                }
                return false;
            }
        }



        //MARK AS SOLUTION
        public bool IsSolved(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var post = db.Posts.Single(p => p.ID == id && p.UserID == _userId);
                post.Solved = true;
                return db.SaveChanges() == 1;
            }
        }
    }
}
