using System.Threading.Tasks;
using QuickBlog.DAL.Models;

namespace QuickBlog.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public ApplicationUser GetUserById(string userId);
        public Task<ApplicationUser> Update(ApplicationUser applicationUser);
    }
}
