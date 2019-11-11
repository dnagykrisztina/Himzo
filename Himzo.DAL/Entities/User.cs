using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Himzo.Dal.Entities
{
    [Table("Users")]
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string University { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [InverseProperty("User")]
        public ICollection<Order> Orders { get; set; }
        [InverseProperty("User")]
        public ICollection<Comment> Comments { get; set; }
    }
}
