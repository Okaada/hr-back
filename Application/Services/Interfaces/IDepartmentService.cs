using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartment(DepartmentDTO departmentDTO);
        void UpdateDepartment(DepartmentDTO departmentDTO, int id);
        void DeleteDepartment(int id);
        
    }
}
