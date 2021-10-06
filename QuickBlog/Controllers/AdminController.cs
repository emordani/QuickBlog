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
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            _adminService = adminService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            return View(await _adminService.GetAdminDashboard(User,searchString,page));
        }
        public async Task<IActionResult> About()
        {
            return View(await _adminService.GetAboutViewModel(User));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutViewModel aboutViewModel)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            await _adminService.UpdateAbout(aboutViewModel, User, webRootPath);
            return RedirectToAction("About");
        }
    }
}
