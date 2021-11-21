using hr.api.Infrastructure.RepositoryInterfaces;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace hr.api.Infrastructure.Repository
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        private readonly IUnitOfWork _uow;
        public UserRepository(IUnitOfWork unitOfWork, ApplicationDbContext context) : base(unitOfWork, context)
        {
            _uow = unitOfWork;
        }
    }
}
