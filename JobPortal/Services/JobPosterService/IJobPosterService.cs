using JobPortal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services.JobPosterService
{
    public interface IJobPosterService
    {
        Task InsertJobPosterAsync(JobPoster jobPoster);
        Task UpdateJobPosterAsync(JobPoster jobPoster);
        Task DeleteJobPosterAsync(JobPoster jobPoster);
        Task<JobPoster> GetJobPosterByIdAsync(int id);
    }
}
