using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.DAL.Models;
using QuickBlog.CORE.ViewModels.PostViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(IPostService postService, IWebHostEnvironment webHostEnvironment)
        {
            _postService = postService;
            _webHostEnvironment = webHostEnvironment;
        }
        [ AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            var actionResult = await _postService.GetPostViewModel(id, User);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
        [Route("Post/Create")]
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await _postService.GetEditViewModel(id, User);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
        [HttpPost,Route("Post/Add")]
        public async Task<IActionResult> Add(CreateViewModel createPostViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _postService.CreatePost(createPostViewModel, User, webRootPath);
            return RedirectToAction("Create");
        }
        [HttpPost, Route("Post/Update")]
        public async Task<IActionResult> Update(EditViewModel editViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            ActionResult<EditViewModel> actionResult=await _postService.UpdatePost(editViewModel, User,webRootPath);
            if (actionResult.Result is null)
                return RedirectToAction("Edit", new {id=editViewModel.Post.PostId});
            return actionResult.Result;
        }
        [HttpPost]
        public async Task<IActionResult> Comment(PostViewModel postViewModel)
        {
            ActionResult<Comment> actionResult = await _postService.CreateComment(postViewModel, User);
            if (actionResult.Result is null)
                return RedirectToAction("Index",  new {id = postViewModel.Post.PostId });

            return actionResult.Result;
        }
    }
}
