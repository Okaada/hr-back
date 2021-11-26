using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IBenefitsTypeService
    {
        void CreateBenefit(string benefitName);
        List<BenefitsType> GetBenefits();
        void DeleteBefenit(int id);
        void UpdateBenefits(int id, string newBenefitName);
    }
}
