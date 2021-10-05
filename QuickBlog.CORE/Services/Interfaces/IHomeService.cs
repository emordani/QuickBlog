using Microsoft.AspNetCore.Mvc;
using QuickBlog.CORE.ViewModels.HomeViewModels;

namespace QuickBlog.CORE.Services.Interfaces
{
    public interface IHomeService
    {
        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page);
    }
}
