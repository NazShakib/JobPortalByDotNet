using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Factory
{
    public interface IJobPosterFactory
    {
        Task<JobPosterModel> PreparedRegisterJobPosterAsync(RegisterModel model);
    }
}
