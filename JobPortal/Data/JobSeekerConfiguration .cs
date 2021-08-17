using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Mapping
{
    public class JobSeekerConfiguration
    {
        public JobSeekerConfiguration(EntityTypeBuilder<JobSeeker> entity)
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.FullName);
            entity.Property(t=>t.CreatedAt);
            entity.Property(t=>t.Image);
            entity.Property(t=>t.Institute);
            entity.Property(t=>t.Cv);
            entity.Property(t => t.Register_id)
                .IsRequired();
            entity.HasOne(t => t.Register).WithOne(u => u.JobSeeker).HasForeignKey<JobSeeker>(u => u.Register_id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
