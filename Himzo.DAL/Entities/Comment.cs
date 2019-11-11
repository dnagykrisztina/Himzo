using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Himzo.Dal.Entities
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Content { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
