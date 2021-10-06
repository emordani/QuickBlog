using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Core;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE.ViewModels.AdminViewModels
{
    public class IndexViewModel
    {
        public IPagedList<Post> Posts { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PostCount { get; set; }
    }
}
