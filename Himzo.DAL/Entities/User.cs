using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
    }
}
