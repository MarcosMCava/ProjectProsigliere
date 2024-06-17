using Prosigliere.Data;
using Prosigliere.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Prosigliere.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDatabaseSource _context;
        private List<BlogPost> _blogPosts = new List<BlogPost>();

        public BlogRepository(IDatabaseSource context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetPostById(int id)
        {
            return _blogPosts.FirstOrDefault(p => p.Id == id);
        }

        public void AddPost(BlogPost post)
        {
            _blogPosts.Add(post);
        }

        public void AddComment(int postId, Comment comment)
        {
            var post = _blogPosts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.Comments.Add(comment);
            }
        }
    }
}
