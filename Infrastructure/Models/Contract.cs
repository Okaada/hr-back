using System;
using System.Collections.Generic;

namespace hr_system_v2.Infrastructure.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Function Function { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? FiredDate { get; set; }
        //public IReadOnlyCollection<Dependents> Dependents { get; set; }
        //public IReadOnlyCollection<Benefits> Benefits { get; set; }
    }
}