using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlog.DAL.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Post Post { get; set; }
        public ApplicationUser Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public Comment Parent { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
