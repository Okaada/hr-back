using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public Guid ManagerId { get; set; }
        public string Name { get; set; }

    }
}
