using hr.api.Infrastructure.Repository;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;

namespace hr_system_v2.Infrastructure.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
