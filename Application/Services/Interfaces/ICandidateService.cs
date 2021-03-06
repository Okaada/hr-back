using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<Candidate> CreateCandidate(CandidateDTO canditateDTO);
        Task<List<CandidateDTO>> GetCandidates();
        Task<CandidateDTO> GetCandidateDetail(Guid id);
        void UpdateCandidate(CandidateDTO candidateDTO);
        void DeleteCandidate(Guid id);
    }
}
