using AutoMapper;
using JobPortal.Domains;
using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Factory
{
    public class JobPosterFactory : IJobPosterFactory
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Register> _registerRepository;
        private readonly IRepository<JobPoster> _jobPosterRepository;

        public JobPosterFactory(IMapper mapper,IRepository<Register> registerRepository,
            IRepository<JobPoster> jobPosterRepository)
        {
            _mapper = mapper;
            _registerRepository = registerRepository;
            _jobPosterRepository = jobPosterRepository;
        }
        public async Task<JobPosterModel> PreparedRegisterJobPosterAsync(RegisterModel model)
        {
            try
            {
                var entity = _mapper.Map<Register>(model);
                entity.RoleType = (Role)model.RoleId;
                await _registerRepository.InsertAsync(entity);
                var jobPoster = new JobPosterModel();
                jobPoster.Name = model.FullName;
                var jobPosterEntity = _mapper.Map<JobPoster>(jobPoster);
                jobPosterEntity.Register_id = entity.Id;
                await _jobPosterRepository.InsertAsync(jobPosterEntity);
                return jobPoster;
  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
