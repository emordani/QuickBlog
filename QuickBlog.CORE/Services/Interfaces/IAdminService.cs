using System.Security.Claims;
using System.Threading.Tasks;
using QuickBlog.CORE.ViewModels.AdminViewModels;

namespace QuickBlog.CORE.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal);
        public Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal);
        public Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal, string webRootPath);
    }
}
