using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using QuickBlog.CORE.Interfaces;
using QuickBlog.DAL;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _applicationDbContext.Users
                .FirstOrDefault(user => user.Id == userId);
        }
        public async Task<ApplicationUser> Update(ApplicationUser applicationUser)
        {
            _applicationDbContext.Update(applicationUser);
            await _applicationDbContext.SaveChangesAsync();
            return applicationUser;
        }
    }
}
