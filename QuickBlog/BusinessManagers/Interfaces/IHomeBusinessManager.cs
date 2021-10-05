using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickBlog.Models.HomeViewModels;

namespace QuickBlog.BusinessManagers.Interfaces
{
    public interface IHomeBusinessManager
    {
        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page);
    }
}
