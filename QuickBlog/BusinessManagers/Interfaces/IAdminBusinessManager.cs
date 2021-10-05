using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using QuickBlog.Models.AdminViewModels;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IAdminBusinessManager
    {
        public Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal);
        public Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal);
        public Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
