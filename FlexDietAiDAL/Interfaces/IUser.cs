using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Interfaces
{
    public interface IUser
    {
        public Task<User> CreateAsync(User _object);
        public Task<User> DeleteAsync(User _object);
        public Task<User> UpdateAsync(Guid Id, User _object);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(Guid Id);
        public Task<User?> GetByLoginAsync(string email, string password);
    }
}
