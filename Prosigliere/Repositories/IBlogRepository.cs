using Prosigliere.Entities;
using System.Collections.Generic;

namespace Prosigliere.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<BlogPost> GetAllPosts();
        BlogPost GetPostById(int id);
        void AddPost(BlogPost post);
        void AddComment(int postId, Comment comment);
    }
}
