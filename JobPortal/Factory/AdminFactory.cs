using AutoMapper;
using JobPortal.Domains;
using JobPortal.Models;
using JobPortal.Services.AdminService;
using JobPortal.Services.RegisterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Factory
{
    public class AdminFactory : IAdminFactory
    {
        private readonly IAdminService _adminService;
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;

        public AdminFactory(IAdminService adminService, IRegisterService registerService,IMapper mapper)
        {
            _adminService = adminService;
            _registerService = registerService;
            _mapper = mapper;
        }
        public async Task<AdminModel> PreparedRegisterAdminModelAsync(RegisterModel model)
        {
            try
            {
                var entity = _mapper.Map<Register>(model);
                entity.RoleType = (Role)model.RoleId;
                await _registerService.InsertRegisterAsync(entity);
                var admin = new AdminModel();
                admin.FullName = model.FullName;
                admin.Register_id = entity.Id;
                await _adminService.InsertAdminAsync(_mapper.Map<Admin>(admin));
                return admin;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
