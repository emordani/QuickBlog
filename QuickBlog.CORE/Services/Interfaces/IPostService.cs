using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.CORE.ViewModels.HomeViewModels;
using QuickBlog.CORE.ViewModels.PostViewModels;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE.Services.Interfaces
{
    public interface IPostService
    {
        public  Task<Post> CreatePost(CreateViewModel postViewModel, ClaimsPrincipal claimsPrincipal, string webRootPath);
        public Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        public Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel,
            ClaimsPrincipal claimsPrincipal, string webRootPath);

        public IndexViewModel GetIndexViewModel(string searchString, int? page);
        public Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        public Task<ActionResult<Comment>> CreateComment(PostViewModel postViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
