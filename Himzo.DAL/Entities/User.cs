using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string University { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
