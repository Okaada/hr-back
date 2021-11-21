using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly IUnitOfWork _uow;

        public CandidateService(ICandidateRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<Candidate> CreateCandidate(CanditateDTO canditateDTO)
        {
            var candidate = new Candidate();
            candidate.Adress = canditateDTO.Adress;
            candidate.CEP = canditateDTO.CEP;
            candidate.City = canditateDTO.City;
            candidate.Email = canditateDTO.Email;
            candidate.Name = canditateDTO.Name;
            candidate.Phone = canditateDTO.Phone;
            candidate.Id = Guid.NewGuid();

            _repository.Add(candidate);
            _uow.Commit();

            return candidate;
        }

        public async Task<CanditateDTO> GetCandidateDetail(Guid id)
        {
            var candidate = _repository.Find(id);

            var candidateDTO = new CanditateDTO();
            candidateDTO.Adress = candidate.Adress;
            candidateDTO.CEP = candidate.CEP;
            candidateDTO.City = candidate.City;
            candidateDTO.Email = candidate.Email;
            candidateDTO.Name = candidate.Name;
            candidateDTO.Phone = candidate.Phone;

            return candidateDTO;
        }

        public async Task<List<CanditateDTO>> GetCandidates()
        {
            var candidateList = _repository.List();

            List<CanditateDTO> candidates = new List<CanditateDTO>();

            foreach (var item in candidateList)
            {
                CanditateDTO canditate = new CanditateDTO();
                canditate.Adress = item.Adress;
                canditate.CEP = item.CEP;
                canditate.City = item.City;
                canditate.Email = item.Email;
                canditate.Name = item.Name;
                canditate.Phone = item.Phone;
                candidates.Add(canditate);
            }

            return candidates;
        }
    }
}
