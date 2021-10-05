using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE.Interfaces
{
    public interface IUserService
    {
        public ApplicationUser GetUserById(string userId);
        public Task<ApplicationUser> Update(ApplicationUser applicationUser);
    }
}
