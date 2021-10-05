using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.CORE.Interfaces;
using QuickBlog.DAL.Models;
using QuickBlog.Models.HomeViewModels;

namespace QuickBlog.BusinessManagers
{
    public class HomeBusinessManager : IHomeBusinessManager
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public HomeBusinessManager(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page)
        {
            if(authorId is null)
                return new BadRequestResult();
            ApplicationUser applicationUser = _userService.GetUserById(authorId);
            if(applicationUser is null)
                return new NotFoundResult();
            int pageSize = 20;
            int pageNumber = page ?? 1;
            IEnumerable<Post> posts = _postService.GetPosts(searchString ?? String.Empty)
                .Where(post=>post.Published && post.Creator==applicationUser);
            return new AuthorViewModel
            {
                Author = applicationUser,
                Posts = new StaticPagedList<Post>(posts.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, posts.Count()),
                PageNumber = pageNumber,
                SearchString = searchString
            };
        }
    }
}
