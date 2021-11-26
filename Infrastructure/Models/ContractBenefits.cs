using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace hr_system_v2.Infrastructure.Models
{
    public class ContractBenefits
    {
        public Guid Id { get; set; }
        public Contract Contract { get; set; }
        
        [ForeignKey("Contract")]
        public Guid ContractId { get; set; }

        public BenefitsType BenefitType { get; set; }
        [ForeignKey("BenefitType")]
        public int BenefitTypeId { get; set; }
    }
}