using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuickBlog.CORE.Services.Interfaces;
using QuickBlog.CORE.ViewModels.AdminViewModels;
using QuickBlog.DAL.Models;
using QuickBlog.DAL.Repositories.Interfaces;

namespace QuickBlog.CORE.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public AdminService(UserManager<ApplicationUser> userManager, IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Posts = _postRepository.GetPosts(applicationUser)
            };
        }

        public async Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new AboutViewModel
            {
                Author = applicationUser,
                SubHeader = applicationUser.SubHeader,
                Content = applicationUser.AboutContent
            };
        }

        public async Task UpdateAbout(AboutViewModel aboutViewModel,ClaimsPrincipal claimsPrincipal, string webRootPath)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            applicationUser.SubHeader = aboutViewModel.SubHeader;
            applicationUser.AboutContent = aboutViewModel.Content;
            if (aboutViewModel.HeaderImage != null)
            {
                string pathToImage = $@"{webRootPath}\UserFiles\Users\{applicationUser.Id}\HeaderImage.jpg";

                EnsureFolder(pathToImage);

                await using (var fileStream = new FileStream(pathToImage, FileMode.Create))
                {
                    await aboutViewModel.HeaderImage.CopyToAsync(fileStream);
                }
            }
            await _userRepository.Update(applicationUser);

        }
        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
