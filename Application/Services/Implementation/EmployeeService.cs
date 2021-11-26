using hr.api.Infrastructure.RepositoryInterfaces;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               IUnitOfWork uow,
                               IContractRepository contractRepository,
                               IPersonRepository personRepository)
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
            _contractRepository = contractRepository;
            _personRepository = personRepository;
        }

        public async Task<Employee> CreateEmployee(Contract contract, Person person)
        {
            var emails = _employeeRepository.List();


            var employee = new Employee()
            {
                Contract = contract,
                Id = Guid.NewGuid(),
                IsActive = true,
                Person = person
            };

            employee.Email = GenerateEmail(emails, employee.Person);
           
            _employeeRepository.Add(employee);
            _uow.Commit();

            return employee;
        }

        public void DeleteEmployee(Guid id)
        {
            var employee = _employeeRepository.Find(id);
            _employeeRepository.Delete(employee);

            _uow.Commit();
        }

        public void DesactivateEmployee(Guid id)
        {
            var employee = _employeeRepository.Find(id);

            employee.IsActive = false;
            _employeeRepository.Edit(employee);
            _uow.Commit();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employeeList = _employeeRepository.List().ToList();
            return employeeList;
        }

        public async Task<Employee> GetEmployeesById(Guid id)
        {
            var employee = _employeeRepository.Find(id);
            employee.Person = _personRepository.Find(employee.PersonId);
            employee.Contract = _contractRepository.Find(employee.ContractId);

            return employee;
        }

        public void UpdateContract(Guid id)
        {
            var employee = _employeeRepository.Find(id);
            employee.Contract.Id = Guid.NewGuid();
            _employeeRepository.Edit(employee);
            _uow.Commit();
        }

        private static string GenerateEmail(IQueryable<Employee> emails, Person person)
        {
            var name = person.Name.Split(" ");
            var nameToEmail = name.First() + "." + name.Last() + "@hrsystem.com.br";

            Random rnd = new Random();
            foreach (var item in emails)
            {
                if (item.Email == nameToEmail)
                {
                    var randomNumber = rnd.Next();
                    nameToEmail = name.First() + "." + name.Last() + $"{randomNumber}" + "@hrsystem.com.br";
                    return nameToEmail;
                }
            }
            return nameToEmail;
        }
    }
}
