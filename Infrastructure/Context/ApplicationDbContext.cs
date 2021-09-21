using hr_system_v2.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_system_v2.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Person> People{ get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Function> Functions{ get; set; }
        public DbSet<Gender> Genders{ get; set; }
    }
}
