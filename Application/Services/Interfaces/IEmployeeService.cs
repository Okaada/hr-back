using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Contract contract, Person person);
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeesById(Guid id);
        void DesactivateEmployee(Guid id);
        void DeleteEmployee(Guid id);
        void UpdateContract(Guid id);
    }
}
