using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Application.DTOs
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
    }
}
