using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Domains;

namespace JobPortal.Services.JobDetailsService
{
    public interface IJobDetailsService
    {
        Task InsertJobDetailsAsync(JobDetails jobDetails);
        Task UpdateJobDetailsAsync(JobDetails jobDetails);
        Task DeleteJobDetailsAsync(JobDetails jobDetails);
        Task<JobDetails> GetJobDetailsByIdAsync(int id);
        Task<List<JobDetails>> GetAllJobDetailsListAsync();
    }
}
