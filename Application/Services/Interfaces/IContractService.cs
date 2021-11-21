using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using System;

using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IContractService
    {
        Task<Contract> CreateContract(ContractDTO contractDTO);
        void DeleteContract(Guid contractId);
    }
}
