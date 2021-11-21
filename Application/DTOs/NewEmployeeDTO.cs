using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class NewEmployeeDTO
    {
        public PersonDTO PersonDTO { get; set; }
        public ContractDTO ContractDTO { get; set; }
    }
}
