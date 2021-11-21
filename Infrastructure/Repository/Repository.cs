using hr_system_v2.Infrastructure.Context;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hr.api.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class

    {
        private ApplicationDbContext _context;

        public Repository(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {

            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _context = context;
        }

        public T Find(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void Edit(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
