﻿using System;

namespace hr_system_v2.Infrastructure.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}