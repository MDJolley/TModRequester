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
            var entity = new Post()
            {
                UserID = _userId,
                Title = model.Title,
                Body = model.Body,
                TimePosted = DateTimeOffset.Now
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Posts.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        //GET
        public IEnumerable<PostListItem> GetPostsByUser()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Posts.Where(e => e.UserID == _userId).Select(e => new PostListItem
                {
                    PostID = e.ID,
                    Title = e.Title,
                    TimePosted = e.TimePosted,
                    Votes = e.Votes,
                });
                return query.ToArray();
            }
        }
    }
}
