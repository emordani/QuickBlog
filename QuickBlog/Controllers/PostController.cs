using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.DAL.Models;
using QuickBlog.Models.PostViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostBusinessManager _postBusinessManager;
        public PostController(IPostBusinessManager postBusinessManager)
        {
            _postBusinessManager = postBusinessManager;
        }
        [ AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            ActionResult<PostViewModel> actionResult = await _postBusinessManager.GetPostViewModel(id, User);
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
            ActionResult<EditViewModel> actionResult = await _postBusinessManager.GetEditViewModel(id, User);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
        [HttpPost,Route("Post/Add")]
        public async Task<IActionResult> Add(CreateViewModel createPostViewModel)
        {
            await _postBusinessManager.CreatePost(createPostViewModel, User);
            return RedirectToAction("Create");
        }
        [HttpPost, Route("Post/Update")]
        public async Task<IActionResult> Update(EditViewModel editViewModel)
        {
            ActionResult<EditViewModel> actionResult=await _postBusinessManager.UpdatePost(editViewModel, User);
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
