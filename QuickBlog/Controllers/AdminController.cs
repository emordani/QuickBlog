using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QuickBlog.BusinessManagers.Interfaces;
using QuickBlog.Models.AdminViewModels;

namespace QuickBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminBusinessManager _adminBusinessManager;

        public AdminController(IAdminBusinessManager adminBusinessManager)
        {
            _adminBusinessManager = adminBusinessManager;
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
            await _adminBusinessManager.UpdateAbout(aboutViewModel, User);
            return RedirectToAction("About");
        }
    }
}
