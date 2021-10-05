using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickBlog.CORE.Interfaces;
using QuickBlog.DAL;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public PostService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }
        public async Task<Post> Add(Post post)
        {
            _applicationDbContext.Add(post);
            await _applicationDbContext.SaveChangesAsync();
            return post;

        }
        public async Task<Post> Update(Post post)
        {
            _applicationDbContext.Update(post);
            await _applicationDbContext.SaveChangesAsync();
            return post;

        }

        public IEnumerable<Post> GetPosts(string searchString)
        {
            return _applicationDbContext.Posts
                .OrderByDescending(post => post.CreatedOn)
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                .Where(post => post.Title.Contains(searchString) || post.Content.Contains(searchString));
        }
        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser)
        {
            return _applicationDbContext.Posts
                .Include(post => post.Creator)
                .Include(post => post.Approver)
                .Include(post => post.Comments)
                .Where(post => post.Creator == applicationUser);
        }

        public Post GetPostById(int postId)
        {
            return _applicationDbContext.Posts
                .Include(post=>post.Creator)
                .Include(post=>post.Comments)
                    .ThenInclude(comment=>comment.Author)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Comments)
                        .ThenInclude(replay=>replay.Parent)
                .FirstOrDefault(post => post.PostId == postId);
        }

        public Comment GetCommentById(int commentId)
        {
            return _applicationDbContext.Comments
                .Include(comment => comment.Author)
                .Include(comment => comment.Post)
                .Include(comment => comment.Parent)
                .FirstOrDefault(comment => comment.CommentId == commentId);
        }
        public async Task<Comment> Add(Comment comment)
        {
            _applicationDbContext.Add(comment);
            await _applicationDbContext.SaveChangesAsync();
            return comment;

        }
    }
}
