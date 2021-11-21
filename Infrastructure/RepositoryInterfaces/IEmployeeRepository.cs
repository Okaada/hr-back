using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;

namespace hr.api.Infrastructure.RepositoryInterfaces
{
    public interface IEmployeeRepository: IRepository<Employee>, IDisposable
    {
    }
}
