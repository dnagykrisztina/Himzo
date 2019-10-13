using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Himzo.Dal.Entities
{
    public class Role : IdentityRole<int>
    {
        public const string Admin = "Admin";
        public const string Kortag = "Kortag";
        public const string User = "User";
    }
}
