using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Models
{
    public class Candidate
    {
        public Guid Id {get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Curriculum { get; set; }
    }
}
