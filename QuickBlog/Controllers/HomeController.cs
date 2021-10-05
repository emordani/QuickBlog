using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Models.HomeViewModels;

namespace QuickBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostBusinessManager _postBusinessManager;
        private readonly IHomeBusinessManager _homeBusinessManager;

        public HomeController(IPostBusinessManager postBusinessManager, IHomeBusinessManager homeBusinessManager)
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
