using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Interfaces
{
    public interface IUserHealth
    {
        public Task<UserHealth> CreateAsync(UserHealth _object);
        public Task<UserHealth> DeleteAsync(UserHealth _object);
        public Task<UserHealth> UpdateAsync(int Id, UserHealth _object);
        public Task<UserHealth?> GetByIdAsync(int Id);
    }
}
