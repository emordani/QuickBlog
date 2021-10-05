using QuickBlog.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBlog.DAL.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post> Add(Post post);
        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser);
        public Post GetPostById(int postId);
        public Task<Post> Update(Post post);
        public IEnumerable<Post> GetPosts(string searchString);
        public Comment GetCommentById(int commentId);
        public Task<Comment> Add(Comment comment);
    }
}
