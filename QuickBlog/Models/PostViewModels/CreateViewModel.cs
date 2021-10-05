using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuickBlog.DAL.Models;

namespace QuickBlog.Models.PostViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name="Header Image")]
        public IFormFile PostHeaderImage { get; set; }
        public Post Post { get; set;}
    }
}
