﻿using hr_system_v2.Infrastructure.Models;
using System;

namespace hr_system_v2.Infrastructure.RepositoryInterfaces
{
    public interface ICandidateRepository : IRepository<Candidate>, IDisposable
    {
    
    }
}