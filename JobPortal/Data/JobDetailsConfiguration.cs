using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Mapping
{
    public class JobDetailsConfiguration
    {
        public JobDetailsConfiguration(EntityTypeBuilder<JobDetails> entity)
        {
           
            entity.HasKey(t => t.Id);
            entity.Property(t => t.IsActive);
            entity.Property(t => t.JobDescription);
            entity.Property(t => t.JobLocation);
            entity.Property(t => t.JobPoster_id);
            entity.Property(t => t.CreatedAt);
            entity.Property(t => t.DeadlineAt);
            entity.Property(t => t.JobTitle);
            entity.Property(t => t.NumberOfVacency);
            entity.Property(t => t.JobType);
            entity.HasOne(t => t.JobPoster).WithMany(u => u.JobDetail).HasForeignKey(u => u.JobPoster_id).OnDelete(DeleteBehavior.NoAction);
            entity.HasMany(t => t.JobSeeker).WithMany(u => u.JobDetails);

        }
    }
}
