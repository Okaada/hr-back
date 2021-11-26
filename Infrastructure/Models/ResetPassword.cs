using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Models
{
    public class ResetPassword
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public DateTime InsertDateTimeUTC { get; set; }
    }
}
