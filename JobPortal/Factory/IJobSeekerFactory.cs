using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Factory
{
    public interface IJobSeekerFactory
    {
        Task<JobSeekerModel> PrepeareRegisterJobSeekerModelAsync(RegisterModel model);
    }
}
