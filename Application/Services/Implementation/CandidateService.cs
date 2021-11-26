using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<Candidate> CreateCandidate(CandidateDTO canditateDTO)
        {        
            var candidate = new Candidate();
            candidate.Adress = canditateDTO.Adress;
            candidate.CEP = canditateDTO.CEP;
            candidate.City = canditateDTO.City;
            candidate.Email = canditateDTO.Email;
            candidate.Name = canditateDTO.Name;
            candidate.Phone = canditateDTO.Phone;
            candidate.Id = Guid.NewGuid();

            byte[] fileBytes;

            if(canditateDTO.Curriculum == null)
                candidate.Curriculum = null;
            else
            {
                using (var ms = new MemoryStream())
                {
                    canditateDTO.Curriculum.CopyTo(ms);
                    fileBytes = ms.ToArray();
                    candidate.Curriculum = fileBytes;
                }
            }
            

            _repository.Add(candidate);
            _uow.Commit();

            return candidate;
        }

        public void DeleteCandidate(Guid id)
        {
            var candidate = _repository.Find(id);

            _repository.Delete(candidate);
            _uow.Commit();
        }

        public async Task<CandidateDTO> GetCandidateDetail(Guid id)
        {
            var candidate = _repository.Find(id);

            var candidateDTO = new CandidateDTO();
            candidateDTO.Adress = candidate.Adress;
            candidateDTO.CEP = candidate.CEP;
            candidateDTO.City = candidate.City;
            candidateDTO.Email = candidate.Email;
            candidateDTO.Name = candidate.Name;
            candidateDTO.Phone = candidate.Phone;
            candidateDTO.Id = candidate.Id;

            return candidateDTO;
        }

        public async Task<List<CandidateDTO>> GetCandidates()
        {
            var candidateList = _repository.List();

            List<CandidateDTO> candidates = new List<CandidateDTO>();

            foreach (var item in candidateList)
            {
                CandidateDTO candidate = new CandidateDTO();
                candidate.Adress = item.Adress;
                candidate.CEP = item.CEP;
                candidate.City = item.City;
                candidate.Email = item.Email;
                candidate.Name = item.Name;
                candidate.Phone = item.Phone;
                candidate.Id = item.Id;
                candidates.Add(candidate);
            }

            return candidates;
        }

        public void UpdateCandidate(CandidateDTO candidateDTO)
        {
            var candidate = _repository.Find(candidateDTO.Id);

            candidate.Adress = candidateDTO.Adress;
            candidate.CEP = candidateDTO.CEP;
            candidate.City = candidateDTO.City;
            candidate.Email = candidateDTO.Email;
            candidate.Name = candidateDTO.Name;
            candidate.Phone = candidateDTO.Phone;

            _repository.Edit(candidate);
            _uow.Commit();

        }
    }
}
