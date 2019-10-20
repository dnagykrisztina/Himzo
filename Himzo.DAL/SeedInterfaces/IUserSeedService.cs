using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Himzo.Dal.SeedInterfaces
{
    public interface IUserSeedService
    {
        public Task SeedRoleAsync();
        public Task SeedUserAsync();
    }
}
