using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Address> Address { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public bool IsHandicapped { get; set; }
        public bool IsBloodDonor { get; set; }
    }
}
