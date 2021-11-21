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
    public class DependentService : IDependentService
    {
        private readonly IDependentRepository _repository;
        private readonly IUnitOfWork _uow;

        public DependentService(IUnitOfWork uow, IDependentRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<Dependents> AddDependent(DependentDTO dependentDTO)
        {
            var dependent = new Dependents()
            {
                Id = Guid.NewGuid(),
                Sex = dependentDTO.Sex,
                CPF = dependentDTO.CPF,
                Name = dependentDTO.Name,
                Phone = dependentDTO.Phone,
                BirthDate = dependentDTO.BirthDate,
                EmployeeId = dependentDTO.EmployeeId,
                MothersName = dependentDTO.MothersName,
                FathersName = dependentDTO.FathersName,
                IsBloodDonor = dependentDTO.IsBloodDonor,
                PersonalEmail = dependentDTO.PersonalEmail,
                IsHandicapped = dependentDTO.IsHandicapped
            };

            _repository.Add(dependent);
            _uow.Commit();

            return dependent;
        }

        public void DeleteDependent(Guid id)
        {
            var dependent = _repository.Find(id);
            _repository.Delete(dependent);

        }

        public async Task<Dependents> GetDependentById(Guid id)
        {
            return _repository.Find(id);
        }

        public async Task<List<Dependents>> GetDependents()
        {
            return _repository.List().ToList();
        }

        public Task<Dependents> GetDependentsByCPF(string CPF)
        {
            throw new NotImplementedException();
        }

        public async void UpdateDependent(DependentDTO dependentDTO, Guid id)
        {
            var dependent = _repository.Find(id);


            dependent.Sex = dependentDTO.Sex;
            dependent.Name = dependentDTO.Name;
            dependent.Phone = dependentDTO.Phone;
            dependent.BirthDate = dependentDTO.BirthDate;
            dependent.EmployeeId = dependentDTO.EmployeeId;
            dependent.MothersName = dependentDTO.MothersName;
            dependent.FathersName = dependentDTO.FathersName;
            dependent.IsBloodDonor = dependentDTO.IsBloodDonor;
            dependent.PersonalEmail = dependentDTO.PersonalEmail;
            dependent.IsHandicapped = dependentDTO.IsHandicapped;
            

            _repository.Edit(dependent);
            _uow.Commit();
        }
    }
}
