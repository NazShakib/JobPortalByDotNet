using JobPortal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.Mapping;

namespace JobPortal.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<JobPoster> JobPoster { get; set; }
        public DbSet<JobSeeker> JobSeeker { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<JobDetails> JobDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RegisterConfiguration(modelBuilder.Entity<Register>());
            new AdminConfiguration(modelBuilder.Entity<Admin>());
            new JobPosterConfiguration(modelBuilder.Entity<JobPoster>());
            new JobSeekerConfiguration(modelBuilder.Entity<JobSeeker>());
            new JobDetailsConfiguration(modelBuilder.Entity<JobDetails>());
        }


    }
}
