using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Domains;

namespace JobPortal.Services.AdminService
{
    public interface IAdminService
    {
        Task InsertAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(Admin admin);
        Task<Admin> GetAdminById(int id);

    }
}
