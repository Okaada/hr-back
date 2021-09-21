using hr.api.Infrastructure.RepositoryInterfaces;
using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace hr.api.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Edit(UserInfo item)
        {
            throw new NotImplementedException();
        }

        public UserInfo Find(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> List()
        {
            throw new NotImplementedException();
        }
    }
}
