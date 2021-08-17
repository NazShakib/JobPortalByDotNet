using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Mapping
{
    public class JobPosterConfiguration
    {
        public JobPosterConfiguration(EntityTypeBuilder<JobPoster> entity)
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Register_id)
                .IsRequired();
            entity.Property(t => t.Image);
            entity.Property(t => t.FullName);
            entity.Property(t=>t.CompanyName);
            entity.Property(t => t.CompanyDescription);
            entity.HasOne(t => t.Register).WithOne(u => u.JobPoster).HasForeignKey<JobPoster>(u => u.Register_id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
