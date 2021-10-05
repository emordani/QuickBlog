using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.CORE.ViewModels.HomeViewModels;
using QuickBlog.DAL.Models;
using QuickBlog.DAL.Repositories.Interfaces;


namespace QuickBlog.CORE.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public HomeService(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page)
        {
            if(authorId is null)
                return new BadRequestResult();
            ApplicationUser applicationUser = _userRepository.GetUserById(authorId);
            if(applicationUser is null)
                return new NotFoundResult();
            int pageSize = 20;
            int pageNumber = page ?? 1;
            IEnumerable<Post> posts = _postRepository.GetPosts(searchString ?? String.Empty)
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
