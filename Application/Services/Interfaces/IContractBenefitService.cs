using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IContractBenefitService
    {
        void AddBenefitInContract(int benifitId, Guid contractId);
        void RemoveBenefitFromContract(int benifitId, Guid contractId);
    }
}
