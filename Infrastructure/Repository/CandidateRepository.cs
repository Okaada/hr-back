using hr.api.Infrastructure.Repository;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Repository
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository 
    {
        private readonly IUnitOfWork _unitOfWork;
        public CandidateRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _unitOfWork = unitOfWork;
        }
       
    }
}
