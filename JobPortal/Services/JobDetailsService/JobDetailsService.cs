using JobPortal.Domains;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services.JobDetailsService
{
    public class JobDetailsService : IJobDetailsService
    {
        private readonly IRepository<JobDetails> _jobDetailsRepository;

        public JobDetailsService(IRepository<JobDetails> jobDetailsRepository)
        {
            _jobDetailsRepository = jobDetailsRepository;
        }
        public async Task DeleteJobDetailsAsync(JobDetails jobDetails)
        {
            await _jobDetailsRepository.DeleteAsync(jobDetails);
        }

        public async Task<List<JobDetails>> GetAllJobDetailsListAsync()
        {
            return await _jobDetailsRepository.GetAllAsync();
        }

        public async Task<JobDetails> GetJobDetailsByIdAsync(int id)
        {
            return await  _jobDetailsRepository.GetByIdAsync(id);
        }

        public async Task InsertJobDetailsAsync(JobDetails jobDetails)
        {
            await _jobDetailsRepository.InsertAsync(jobDetails);
        }

        public async Task UpdateJobDetailsAsync(JobDetails jobDetails)
        {
            await _jobDetailsRepository.UpdateAsync(jobDetails);
        }
    }
}
