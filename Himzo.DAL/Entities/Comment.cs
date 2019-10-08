using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
    }
}
