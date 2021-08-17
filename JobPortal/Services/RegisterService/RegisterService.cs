using JobPortal.Domains;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobPortal.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IRepository<Register> _registerRepository;
        public RegisterService(IRepository<Register> registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public async Task DeleteRegisterAsync(Register register)
        {
            await _registerRepository.DeleteAsync(register);
        }

        public async Task<Register> GetRegisterByEmailAndPasswordAsync(string email, string password)
        {
            return await _registerRepository.GetByFilterAsync(q => q.Email == email && q.Password == password);
        }

        public async Task<Register> GetRegisterByIdAsync(int id)
        {
           return await _registerRepository.GetByIdAsync(id);
        }

        public async Task InsertRegisterAsync(Register register)
        {
            await _registerRepository.InsertAsync(register);
        }

        public async Task UpdateRegisterAsync(Register register)
        {
            await _registerRepository.UpdateAsync(register);
        }
    }
}
