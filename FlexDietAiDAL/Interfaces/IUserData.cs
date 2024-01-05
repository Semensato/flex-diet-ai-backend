using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Interfaces
{
    public interface IUserData
    {
        public Task<UserData> CreateAsync(UserData _object);
        public Task<UserData> DeleteAsync(UserData _object);
        public Task<UserData> UpdateAsync(int Id, UserData _object);
    }
}
