using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Mapping
{
    public class AdminConfiguration
    {
        public AdminConfiguration(EntityTypeBuilder<Admin> entity)
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.FullName);
            entity.Property(t => t.Register_id)
                .IsRequired();

            entity.HasOne(t => t.Register).WithOne(t => t.Admin).HasForeignKey<Admin>(u => u.Register_id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
