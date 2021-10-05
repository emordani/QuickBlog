using QuickBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.CORE.Interfaces
{
    public interface IPostService
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
