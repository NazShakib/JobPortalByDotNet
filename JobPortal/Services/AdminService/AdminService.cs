using JobPortal.Domains;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepository;

        public AdminService(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task DeleteAdminAsync(Admin admin)
        {
            await _adminRepository.DeleteAsync(admin);
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await  _adminRepository.GetByIdAsync(id);
        }

        public async Task InsertAdminAsync(Admin admin)
        {
            await _adminRepository.InsertAsync(admin);
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            await _adminRepository.UpdateAsync(admin);
        }
    }
}
