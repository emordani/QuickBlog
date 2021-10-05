using System.Linq;
using System.Threading.Tasks;
using QuickBlog.DAL.Models;
using QuickBlog.DAL.Repositories.Interfaces;

namespace QuickBlog.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
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
