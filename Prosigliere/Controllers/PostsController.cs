using Microsoft.AspNetCore.Mvc;
using Prosigliere.Entities;
using Prosigliere.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Prosigliere.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepository _repository;

        public PostsController(IBlogRepository repository)
        {
            _repository = repository;
        }

        [Route("getposts")]
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetPosts()
        {
            var posts = _repository.GetAllPosts().Select(post => new
                {
                    post.Id,
                    post.Title,
                    NumberOfComments = post.Comments.Count
                });
            return Ok(posts);
        }

        [Route("addpost")]
        [HttpPost]
        public ActionResult<BlogPost> AddPost(BlogPost post)
        {
            _repository.AddPost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetPostById(int id)
        {
            var post = _repository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost("{id}/comments")]
        public ActionResult AddCommentToPost(int id, Comment comment)
        {
            var post = _repository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            _repository.AddComment(id, comment);
            return CreatedAtAction(nameof(GetPostById), new { id }, post);
        }
    }
}
