using Microsoft.AspNetCore.Mvc;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.CORE.ViewModels.HomeViewModels;

namespace QuickBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly CORE.Services.Interfaces.IPostService _postBusinessManager;
        private readonly IHomeService _homeBusinessManager;

        public HomeController(CORE.Services.Interfaces.IPostService postBusinessManager, IHomeService homeBusinessManager)
        {
            _postBusinessManager = postBusinessManager;
            _homeBusinessManager = homeBusinessManager;
        }
        [Route("/")]
        public IActionResult Index(string searchString, int? page)
        {
            return View(_postBusinessManager.GetIndexViewModel(searchString,page));
        }

        public IActionResult Author(string authorId, string searchString, int? page)
        {
            ActionResult<AuthorViewModel> actionResult = _homeBusinessManager
                .GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);
            return actionResult.Result;
        }
    }
}
