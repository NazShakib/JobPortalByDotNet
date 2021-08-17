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
    public class JobSeekerFactory : IJobSeekerFactory
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Register> _registerRepository;
        private readonly IRepository<JobSeeker> _jobSeekerRepository;

        public JobSeekerFactory(IMapper mapper, IRepository<Register> registerRepository, IRepository<JobSeeker> jobSeekerRepository)
        {
            _mapper = mapper;
            _registerRepository = registerRepository;
            _jobSeekerRepository = jobSeekerRepository;
        }
        public async Task<JobSeekerModel> PrepeareRegisterJobSeekerModelAsync(RegisterModel model)
        {
            try
            {
                var entity = _mapper.Map<Register>(model);
                entity.RoleType = (Role)model.RoleId;
                await _registerRepository.InsertAsync(entity);
                var jobseeker = new JobSeekerModel();
                jobseeker.Name = model.FullName;
                jobseeker.CreatedAt = DateTime.Now;
                var seeker = _mapper.Map<JobSeeker>(jobseeker);
                seeker.Register_id = entity.Id;
                await _jobSeekerRepository.InsertAsync(seeker);
                return jobseeker;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
