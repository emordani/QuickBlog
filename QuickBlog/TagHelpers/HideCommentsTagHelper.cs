using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace QuickBlog.TagHelpers
{
    public class HideCommentsTagHelper : TagHelper
    {
        public IEnumerable<object> CommentList { get; set; }
        public int CommentCount { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            if (CommentList.Count() <= CommentCount)
                output.SuppressOutput();
        }
    }
}
