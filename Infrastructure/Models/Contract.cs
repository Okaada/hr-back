using System;
using System.Collections.Generic;

namespace hr_system_v2.Infrastructure.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Function { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? FiredDate { get; set; }
        public double Salary { get; set; }
    }
}