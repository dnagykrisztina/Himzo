using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Himzo.Dal.Entities
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string University { get; set; }

        [InverseProperty("User")]
        public ICollection<Order> Orders { get; set; }
        [InverseProperty("User")]
        public ICollection<Comment> Comments { get; set; }
    }
}
