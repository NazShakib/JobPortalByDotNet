using JobPortal.Domains;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Services.JobSeekerService
{
    public class JobSeekerService : IJobSeekerService
    {
        private readonly IRepository<JobSeeker> _jobSeekerRepository;

        public JobSeekerService(IRepository<JobSeeker> jobSeekerRepository)
        {
            _jobSeekerRepository = jobSeekerRepository;
        }
        public async Task DeleteJobSeekerAsync(JobSeeker jobSeeker)
        {
            await _jobSeekerRepository.DeleteAsync(jobSeeker);
        }

        public async Task<JobSeeker> GetJobSeekerByFilterAsync(Expression<Func<JobSeeker, bool>> filter)
        {
            return await _jobSeekerRepository.GetByFilterAsync(filter);
        }

        public async Task<JobSeeker> GetJobSeekerByIdAsync(int id)
        {
            return await _jobSeekerRepository.GetByIdAsync(id);
        }

        public async Task InsertJobSeekerAsync(JobSeeker jobSeeker)
        {
            await _jobSeekerRepository.InsertAsync(jobSeeker);
        }

        public async Task UpdateJobSeekerAsync(JobSeeker jobSeeker)
        {
            await _jobSeekerRepository.UpdateAsync(jobSeeker);
        }
    }
}
