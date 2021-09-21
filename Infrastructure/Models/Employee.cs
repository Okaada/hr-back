using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public Contract Contract { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
