using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class ContractBenefitService : IContractBenefitService
    {
        private readonly IUnitOfWork _uow;
        private readonly IContractBenefitsRepository _repo;
        public ContractBenefitService(IUnitOfWork uow, IContractBenefitsRepository repo)
        {
            _uow = uow;
            _repo = repo;
        }

        public void AddBenefitInContract(int benifitId, Guid contractId)
        {
            var addedBenefit = new ContractBenefits()
            {
                BenefitTypeId = benifitId,
                ContractId = contractId,
                Id = Guid.NewGuid()
            };

            _repo.Add(addedBenefit);
            _uow.Commit();
        }

        public void RemoveBenefitFromContract(int benifitId, Guid contractId)
        {
            var toDeleteBenefit = _repo.List().Where(x => x.ContractId == contractId && x.BenefitTypeId == benifitId).FirstOrDefault();

            _repo.Delete(toDeleteBenefit);
            _uow.Commit();
        }
    }
}
