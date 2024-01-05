using FlexDietAiDAL.Data;
using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Repositories
{  
    /// <summary>
    /// UserData repository to access database.
    /// </summary>
    public class RepositoryUserData : IUserData
    {
        FlexDietAiDbContext _dbContext;

        public RepositoryUserData(FlexDietAiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserData> CreateAsync(UserData _object)
        {
            var obj = await _dbContext.UsersData.AddAsync(_object);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<UserData> DeleteAsync(UserData _object)
        {
            _dbContext.UsersData.Remove(_object);
            await _dbContext.SaveChangesAsync();
            return _object;
        }

        public async Task<UserData> UpdateAsync(int Id, UserData _object)
        {
            var userData = await _dbContext.UsersData.FindAsync(Id);

            userData.Name = _object.Name;
            userData.LastName = _object.LastName;
            userData.Dof = _object.Dof;
            userData.Somatotype = _object.Somatotype;

            await _dbContext.SaveChangesAsync();
            return userData;
        }

        public async Task<UserData?> GetByIdAsync(int Id)
        {
            return await _dbContext.UsersData.FindAsync(Id);
        }
    }
}
