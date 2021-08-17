using JobPortal.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Data.Mapping
{
    public class RegisterConfiguration 
    {
        public RegisterConfiguration(EntityTypeBuilder<Register> entity)
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Email)
                .IsRequired();
            entity.Property(t => t.Password)
                .IsRequired();
        }
    }
}
