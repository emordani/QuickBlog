using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.CORE.ViewModels.AdminViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminBusinessManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminService adminBusinessManager, IWebHostEnvironment webHostEnvironment)
        {
            _adminBusinessManager = adminBusinessManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _adminBusinessManager.GetAdminDashboard(User));
        }
        public async Task<IActionResult> About()
        {
            return View(await _adminBusinessManager.GetAboutViewModel(User));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutViewModel aboutViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _adminBusinessManager.UpdateAbout(aboutViewModel, User, webRootPath);
            return RedirectToAction("About");
        }
    }
}
