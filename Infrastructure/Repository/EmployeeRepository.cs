using hr.api.Infrastructure.Repository;
using hr.api.Infrastructure.RepositoryInterfaces;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;

namespace hr_system_v2.Infrastructure.Repository
{
    public class EmployeeRepository: Repository<Employee>, IEmployeeRepository 
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
