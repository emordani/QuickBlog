using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuickBlog.DAL.Models;

namespace QuickBlog.CORE.ViewModels.AdminViewModels
{
    public class AboutViewModel
    {
        public ApplicationUser Author { get; set; }
        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }
        [Display(Name = "Sub-Header")]
        public string SubHeader { get; set; }
        public string Content { get; set; }
    }
}
