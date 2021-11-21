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
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _uow;

        public ContractService(IContractRepository contractRepository, IUnitOfWork uow)
        {
            _contractRepository = contractRepository;
            _uow = uow;
        }
        private async Task<List<Dependents>> BuildDependents(List<DependentDTO> dependents)
        {
            var dependentsList = new List<Dependents>();

            foreach (var item in dependents)
            {
                var newDependent = new Dependents();
                newDependent.FathersName = item.FathersName;
                newDependent.BirthDate = item.BirthDate;
                newDependent.CPF = item.CPF;
                newDependent.Sex = item.Sex;
                newDependent.PersonalEmail = item.PersonalEmail;
                newDependent.Phone = item.Phone;
                newDependent.Name = item.Name;
                newDependent.MothersName = item.MothersName;
                newDependent.IsBloodDonor = item.IsBloodDonor;
                newDependent.IsHandicapped = item.IsBloodDonor;
                newDependent.Id = Guid.NewGuid();

                dependentsList.Add(newDependent);
            }

            return dependentsList;
        }

        public async Task<Contract> CreateContract(ContractDTO contractDto)
        {

            var contract = new Contract()
            {
                Id = Guid.NewGuid(),
                HireDate = contractDto.HireDate,
                FiredDate = null,
            };

            _contractRepository.Add(contract);
            _uow.Commit();

            return contract;
        }

        public void DeleteContract(Guid contractId)
        {
            var contract = _contractRepository.Find(contractId);
           
            _contractRepository.Delete(contract);
            _uow.Commit();
        }
    }
}
