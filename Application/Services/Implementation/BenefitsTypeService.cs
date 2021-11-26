using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class BenefitsTypeService : IBenefitsTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IBenefitsRepository _repo;

        public BenefitsTypeService(IBenefitsRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public void CreateBenefit(string benefitName)
        {
            var benefit = new BenefitsType()
            {
                Name = benefitName
            };

            _repo.Add(benefit);
            _uow.Commit();
        }

        public List<BenefitsType> GetBenefits()
        {
            return _repo.List().ToList(); 
        }

        public void DeleteBefenit(int id)
        {
            var benefit = _repo.Find(id);

            _repo.Delete(benefit);
            _uow.Commit();

        }

        public void UpdateBenefits(int id, string newBenefitName)
        {
            var benefit = _repo.Find(id);
            benefit.Name = newBenefitName;

            _repo.Edit(benefit);
            _uow.Commit();
        }
    }
}
