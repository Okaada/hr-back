using hr.api.Infrastructure.Repository;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;

namespace hr_system_v2.Infrastructure.Repository
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContractRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
