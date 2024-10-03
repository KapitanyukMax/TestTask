using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(i => i.Name);

            builder.Property(i => i.Name)
                .HasMaxLength(36)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(i => i.Account)
                .WithMany(a => a.Incidents)
                .HasForeignKey(i => i.AccountName);

            builder.ToTable("Incidents");
        }
    }
}
