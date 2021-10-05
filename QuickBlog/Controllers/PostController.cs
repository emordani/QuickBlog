using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.DAL.Models;
//using QuickBlog.Models.PostViewModels;
using QuickBlog.CORE.ViewModels.PostViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postBusinessManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(IPostService postBusinessManager, IWebHostEnvironment webHostEnvironment)
        {
            _postBusinessManager = postBusinessManager;
            _webHostEnvironment = webHostEnvironment;
        }
        [ AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            var actionResult = await _postBusinessManager.GetPostViewModel(id, User);
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
            var actionResult = await _postBusinessManager.GetEditViewModel(id, User);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
        [HttpPost,Route("Post/Add")]
        public async Task<IActionResult> Add(CORE.ViewModels.PostViewModels.CreateViewModel createPostViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _postBusinessManager.CreatePost(createPostViewModel, User, webRootPath);
            return RedirectToAction("Create");
        }
        [HttpPost, Route("Post/Update")]
        public async Task<IActionResult> Update(EditViewModel editViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            ActionResult<EditViewModel> actionResult=await _postBusinessManager.UpdatePost(editViewModel, User,webRootPath);
            if (actionResult.Result is null)
                return RedirectToAction("Edit", new {id=editViewModel.Post.PostId});

            return actionResult.Result;
        }
        [HttpPost]
        public async Task<IActionResult> Comment(PostViewModel postViewModel)
        {
            ActionResult<Comment> actionResult = await _postBusinessManager.CreateComment(postViewModel, User);
            if (actionResult.Result is null)
                return RedirectToAction("Index",  new {id = postViewModel.Post.PostId });

            return actionResult.Result;
        }
    }
}
