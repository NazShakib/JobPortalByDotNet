using JobPortal.Domains;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services.JobPosterService
{
    public class JobPosterService : IJobPosterService
    {
        private readonly IRepository<JobPoster> _jobPosterReposiotry;

        public JobPosterService(IRepository<JobPoster> jobPosterReposiotry)
        {
            _jobPosterReposiotry = jobPosterReposiotry;
        }
        public async Task DeleteJobPosterAsync(JobPoster jobPoster)
        {
            await _jobPosterReposiotry.DeleteAsync(jobPoster);
        }
        public async Task<JobPoster> GetJobPosterByIdAsync(int id)
        {
            return await _jobPosterReposiotry.GetByIdAsync(id);
        }

        public async Task InsertJobPosterAsync(JobPoster jobPoster)
        {
            await _jobPosterReposiotry.InsertAsync(jobPoster);
        }

        public async Task UpdateJobPosterAsync(JobPoster jobPoster)
        {
            await _jobPosterReposiotry.UpdateAsync(jobPoster);
        }
    }
}
