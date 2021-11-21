using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
