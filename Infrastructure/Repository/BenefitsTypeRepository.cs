using hr.api.Infrastructure.Repository;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;

namespace hr_system_v2.Infrastructure.Repository
{
    public class BenefitsTypeRepository : Repository<BenefitsType>, IBenefitsRepository
    {
        private readonly IUnitOfWork _uow;
        public BenefitsTypeRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _uow = unitOfWork;
        }
    }
}
