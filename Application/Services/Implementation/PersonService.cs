using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
using hr_system_v2.Infrastructure.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hr_system_v2.Application.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _uow;

        public PersonService(IPersonRepository personRepository, IUnitOfWork uow)
        {
            _personRepository = personRepository;
            _uow = uow;
        }

        public async Task<Address> BuildAddress(AddressDTO address)
        {

            var newAddress = new Address();
            newAddress.City = address.City;
            newAddress.Code = address.Code;
            newAddress.District = address.District;
            newAddress.Number = address.Number;
            newAddress.State = address.State;
            newAddress.Street = address.Street;
            newAddress.PersonId = address.PersonId;
            newAddress.Id = Guid.NewGuid();

            return newAddress;
        }

        public async Task<Person> CreatePerson(PersonDTO personDto)
        {
            var address = await BuildAddress(personDto.Address);
            var person = new Person()
            {
                Address = address,
                BirthDate = personDto.BirthDate,
                CPF = personDto.CPF,
                FathersName = personDto.FathersName,
                MothersName = personDto.MothersName,
                Id = Guid.NewGuid(),
                IsBloodDonor = personDto.IsBloodDonor,
                IsHandicapped = personDto.IsHandicapped,
                Name = personDto.Name,
                PersonalEmail = personDto.PersonalEmail,
                Phone = personDto.Phone,
                Sex = personDto.Sex
            };

            _personRepository.Add(person);
            _uow.Commit();

            return person;
        }

        public void DeletePersonById(Guid id)
        {
            var person = _personRepository.Find(id);
            _personRepository.Delete(person);

            _uow.Commit();
        }

        public Task<PersonDTO> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetPersonByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public async void UpdatePerson(PersonDTO personDto, Guid id)
        {
            var address = await BuildAddress(personDto.Address);
            var person = _personRepository.Find(id);

            person.Address = address;
            person.BirthDate = personDto.BirthDate;
            person.CPF = personDto.CPF;
            person.FathersName = personDto.FathersName;
            person.MothersName = personDto.MothersName;
            person.IsBloodDonor = personDto.IsBloodDonor;
            person.IsHandicapped = personDto.IsHandicapped;
            person.Name = personDto.Name;
            person.PersonalEmail = personDto.PersonalEmail;
            person.Phone = personDto.Phone;
            person.Sex = personDto.Sex;

            _personRepository.Edit(person);
            _uow.Commit();

        }
    }
}
