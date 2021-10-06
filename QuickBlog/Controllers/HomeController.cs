using Microsoft.AspNetCore.Mvc;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.CORE.ViewModels.HomeViewModels;

namespace QuickBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IHomeService _homeService;

        public HomeController(IPostService postService, IHomeService homeBusinessManager)
        {
            _postService = postService;
            _homeService = homeBusinessManager;
        }
        [Route("/")]
        public IActionResult Index(string searchString, int? page)
        {
            return View(_postService.GetIndexViewModel(searchString,page));
        }

        public IActionResult Author(string authorId, string searchString, int? page)
        {
            ActionResult<AuthorViewModel> actionResult = _homeService
                .GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
    }
}
