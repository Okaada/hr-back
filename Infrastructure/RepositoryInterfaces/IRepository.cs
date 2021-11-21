using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        T Find(Guid id);
        IQueryable<T> List();
        void Add(T item);
        void Delete(T item);
        void Edit(T item);
    }
}
