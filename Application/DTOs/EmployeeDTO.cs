using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class EmployeeDTO
    {
        public Guid ContractId { get; set; }
        public Guid PersonId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
