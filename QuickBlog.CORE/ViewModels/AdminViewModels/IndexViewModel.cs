using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE.ViewModels.AdminViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
