using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.RepositoryInterfaces
{
    public interface IUserRepository: IRepository<UserInfo>, IDisposable
    {
        
    }
}
