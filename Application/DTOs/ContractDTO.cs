using hr_system_v2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class ContractDTO
    {
        public string Function { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? FiredDate { get; set; }
        public double Salary { get; set; }
        //public IReadOnlyCollection<Benefits> Benefits { get; set; }
    }
}
