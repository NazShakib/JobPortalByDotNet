using JobPortal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Services.JobSeekerService
{
    public interface IJobSeekerService
    {
        Task InsertJobSeekerAsync(JobSeeker jobSeeker);
        Task UpdateJobSeekerAsync(JobSeeker jobSeeker);
        Task DeleteJobSeekerAsync(JobSeeker jobSeeker);
        Task<JobSeeker> GetJobSeekerByIdAsync(int id);
        Task<JobSeeker> GetJobSeekerByFilterAsync(Expression<Func<JobSeeker, bool>> filter);
    }
}
