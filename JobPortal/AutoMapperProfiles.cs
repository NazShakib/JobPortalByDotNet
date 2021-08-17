using AutoMapper;
using JobPortal.Domains;
using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Register, RegisterModel>()
                .ForMember(model => model.AvaliableRoles, option => option.Ignore())
                .ForMember(model =>model.RoleId,option=>option.Ignore())
                .ForMember(model =>model.FullName,option=>option.Ignore());
            CreateMap<RegisterModel, Register>()
                .ForMember(entity => entity.JobPoster, option => option.Ignore())
                .ForMember(entity => entity.JobSeeker, option => option.Ignore())
                .ForMember(entity => entity.Admin, option => option.Ignore())
                .ForMember(entity => entity.RoleType, option => option.Ignore());

            CreateMap<LoginModel, Register>()
                .ForMember(entity => entity.JobPoster, option => option.Ignore())
                .ForMember(entity => entity.JobSeeker, option => option.Ignore())
                .ForMember(entity => entity.RoleType, option => option.Ignore())
                .ForMember(entity => entity.Id, option => option.Ignore())
                .ReverseMap();

           // CreateMap<Admin, AdminModel>();
            CreateMap<AdminModel, Admin>()
                .ForMember(entity => entity.Register, option => option.Ignore())
                .ReverseMap();

            CreateMap<JobSeeker, JobSeekerModel>()
                .ForMember(model => model.Name, option => option.MapFrom(des => des.FullName))
                .ForMember(model => model.Image, option => option.Ignore())
                .ForMember(model => model.Cv, option => option.Ignore());
            CreateMap<JobSeekerModel, JobSeeker>()
                .ForMember(entity => entity.JobDetails, option => option.Ignore())
                .ForMember(entity => entity.Register, option => option.Ignore())
                .ForMember(entity => entity.FullName,option=>option.MapFrom(des=>des.Name))
                .ForMember(entity => entity.Image,option=>option.Ignore())
                .ForMember(entity =>entity.Cv,option=>option.Ignore());

            CreateMap<JobPoster, JobPosterModel>()
                .ForMember(model => model.Name, option => option.MapFrom(des => des.FullName));
            CreateMap<JobPosterModel, JobPoster>()
                .ForMember(entity => entity.JobDetail, option => option.Ignore())
                .ForMember(entity => entity.Register, option => option.Ignore())
                .ForMember(entity => entity.Register_id, option => option.Ignore())
                .ForMember(entity => entity.FullName, option => option.MapFrom(des => des.Name));
        }
    }
}
