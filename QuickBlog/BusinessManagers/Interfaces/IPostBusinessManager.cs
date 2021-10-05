using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.DAL.Models;
using QuickBlog.Models.HomeViewModels;
using QuickBlog.Models.PostViewModels;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IPostBusinessManager
    {
        public  Task<Post> CreatePost(CreateViewModel postViewModel, ClaimsPrincipal claimsPrincipal);
        public Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        public Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel,
            ClaimsPrincipal claimsPrincipal);

        public IndexViewModel GetIndexViewModel(string searchString, int? page);
        public Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        public Task<ActionResult<Comment>> CreateComment(PostViewModel postViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
