using hr_system_v2.Application.DTOs;
using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> CreatePerson(PersonDTO personDto);
        void UpdatePerson(PersonDTO personDto, Guid id);
        void DeletePersonById(Guid id);
        Task<PersonDTO> GetPeople();
        Task<PersonDTO> GetPersonByCPF(string cpf);
        Task<Address> BuildAddress(AddressDTO address);
    }
}
