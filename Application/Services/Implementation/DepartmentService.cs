using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUnitOfWork _uow;

        public DepartmentService(IDepartmentRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<Department> AddDepartment(DepartmentDTO departmentDTO)
        { 
            var department = new Department()
            {
                ManagerId = departmentDTO.EmployeeId,
                Name = departmentDTO.Name
            };

            _repository.Add(department);
            _uow.Commit();

            return department;
        }

        public void DeleteDepartment(int id)
        {
            var dep = _repository.Find(id);

            _repository.Delete(dep);
            _uow.Commit();
        }

        public void UpdateDepartment(DepartmentDTO departmentDTO, int id)
        {
            throw new NotImplementedException();
        }
    }
}
