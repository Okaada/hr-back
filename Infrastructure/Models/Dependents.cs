using System;

namespace hr_system_v2.Infrastructure.Models
{
    public class Dependents
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
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