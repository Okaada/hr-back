using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IDependentService
    {
        Task<Dependents> AddDependent(DependentDTO dependentDTO);
        void DeleteDependent(Guid id);
        void UpdateDependent(DependentDTO dependentDTO, Guid id);
        Task<List<Dependents>> GetDependents();
        Task<Dependents> GetDependentsByCPF(string CPF);
        Task<Dependents> GetDependentById(Guid id);
    }
}
