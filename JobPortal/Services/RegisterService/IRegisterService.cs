using JobPortal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Services.RegisterService
{
    public interface IRegisterService
    {
        Task InsertRegisterAsync(Register register);
        Task UpdateRegisterAsync(Register register);
        Task DeleteRegisterAsync(Register register);
        Task<Register> GetRegisterByIdAsync(int id);
        Task<Register> GetRegisterByEmailAndPasswordAsync(string email, string password);
    }
}
