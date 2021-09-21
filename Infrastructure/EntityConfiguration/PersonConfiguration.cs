using hr_system_v2.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr.api.Infrastructure.EntityConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .IsRequired();

            builder.Property(c => c.CPF)
                   .IsRequired();

            builder.Property(c => c.MothersName)
                   .IsRequired();

            builder.Property(c => c.Sex)
                   .IsRequired()
                   .HasMaxLength(1);

            builder.Property(c => c.BirthDate)
                   .IsRequired();

            builder.Property(c => c.Name)
                   .IsRequired();

            builder.Property(c => c.Gender)
                   .IsRequired();

            builder.OwnsMany(c => c.Address, owner => { owner.HasKey("PersonId"); });
                   

            builder.Property(c => c.FathersName);

            builder.Property(c => c.IsHandicapped);

        }
    }
}
